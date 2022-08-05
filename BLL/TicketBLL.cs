using Microsoft.EntityFrameworkCore;
using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using System;
using System.Collections;

namespace MyLotoRewards.BLL
{
    public class TicketsBLL
    {
        private Context _context;
        public TicketsBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int ticketID)
        {
            return _context.Tickets.Any(ticket => ticket.TicketId == ticketID);
        }

        public bool Guardar(int usuarioId, Tickets ticket)
        {
            return (!Existe(ticket.TicketId)) ? Insertar(usuarioId, ticket) : Modificar(usuarioId, ticket);
        }

        public bool Insertar(int usuarioId, Tickets ticket)
        {
            UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
            var usuario = usuariosBLL.Buscar(usuarioId);
            foreach (var jg in ticket.Jugadas)
            {
                ticket.Total += jg.Monto;
            }
            ticket.Total--;
            usuario.TotalInvertido += ticket.Total;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.Tickets.Add(ticket);

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ticket).State = EntityState.Detached;
            _context.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }

        public bool Modificar(int usuarioId, Tickets ticket)
        {
            UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
            var usuario = usuariosBLL.Buscar(usuarioId);
            
            usuario.TotalInvertido -= ticket.Total;

            _context.Database.ExecuteSqlRaw($"DELETE FROM Jugadas WHERE TicketId={ticket.TicketId};");

            ticket.Total = 0;
            foreach (var jg in ticket.Jugadas)
            {
                ticket.Total += jg.Monto;
                _context.Entry(jg).State = EntityState.Added;
            }
            usuario.TotalInvertido += ticket.Total;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.Entry(ticket).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ticket).State = EntityState.Detached;
            _context.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(int usuarioId, Tickets ticket)
        {
            if (Existe(ticket.TicketId))
			{
                UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
                var usuario = usuariosBLL.Buscar(usuarioId);

                usuario.TotalInvertido -= ticket.Total;

                _context.Database.ExecuteSqlRaw($"DELETE FROM Jugadas WHERE TicketId={ticket.TicketId};");

                _context.Entry(ticket).State = EntityState.Deleted;
                _context.Entry(usuario).State = EntityState.Modified;

                var elimino = _context.SaveChanges() > 0;
                _context.Entry(usuario).State = EntityState.Detached;
                return elimino;
            }
			else
			{
                return false;
			}

        }

        public Tickets? Buscar(int usuarioId, int ticketId)
        {
            var query = _context.Tickets.AsQueryable();

            if (usuarioId > 0)
                query = query.Where(t => t.UsuarioId == usuarioId);

            query = query.Where(t => t.TicketId == ticketId)
                .Include(t => t.Jugadas)
                .AsNoTracking();

            var ticket = query.SingleOrDefault();


            return (query != null) ? prepararInstancia(ticket) : ticket;
        }

        public List<Tickets>? GetListFiltred(
            int usuarioId,
            DateTime fechaDesde,
            DateTime fechaHasta,
            int loteriaId,
            int tipoJugadaId,
            double montoDesde,
            double montoHasta
            )
        {
            var query = _context.Tickets.AsQueryable();
            query = query.Where(t => t.UsuarioId == usuarioId);
            if (montoHasta > 0)
                query = query.Where(t => montoDesde <= t.Total && montoHasta >= t.Total);

            query = query.Where(g => fechaDesde <= g.Fecha && fechaHasta >= g.Fecha)
                .Include(g => g.Jugadas)
                .AsNoTracking();

            List<Tickets>? ticketsTmp = query.ToList();
            List<Tickets>? tickets = new List<Tickets>();

            if (ticketsTmp != null && ticketsTmp.Count > 0)
            {
                foreach (var tk in ticketsTmp)
                {
                    prepararInstancia(tk);
                }
            }

            if (loteriaId > 0 || tipoJugadaId > 0)
            {
                foreach (var ticket in ticketsTmp)
                {
                    foreach (var jugada in ticket.Jugadas)
                    {
                        if (tipoJugadaId > 0 && jugada.TipoJugadaId == tipoJugadaId)
                        {
                            tickets.Add(ticket);
                        }
                        else if (tipoJugadaId == 0 && loteriaId > 0 && jugada.LoteriaId == loteriaId)
                        {
                            tickets.Add(ticket);
                        }
                    }
                }
            }
            else
            {
                tickets = ticketsTmp;
            }

            return tickets;
        }

        public List<Tickets>? GetListByFecha(int usuarioId, DateTime fechaDesde, DateTime fechaHasta)
        {
            var query = _context.Tickets.AsQueryable();

            if (usuarioId > 0)
                query = query.Where(t => t.UsuarioId == usuarioId);

            query = query.Where(t => fechaDesde.Date <= t.Fecha.Date && fechaHasta.Date >= t.Fecha.Date)
                .Include(t => t.Jugadas)
                .AsNoTracking();

            var tickets = query.ToList();

            foreach (Tickets tk in tickets)
            {
                prepararInstancia(tk);
            }

            return tickets;
        }

        public List<Tickets>? GetList(int usuarioId)
        {
            var query = _context.Tickets.AsQueryable();

            if (usuarioId > 0)
                query = query.Where(t => t.UsuarioId == usuarioId);

            query = query.Include(t => t.Jugadas)
                .AsNoTracking();

            var tickets = query.ToList();

            if(tickets != null && tickets.Count > 0)
			{
				foreach (Tickets tk in tickets)
				{
                    prepararInstancia(tk);
                }
			}

            return tickets;
        }

        private Tickets prepararInstancia(Tickets tk)
		{
            if (tk != null)
            {
                TiposJugadasBLL tiposJugadasBLL = new TiposJugadasBLL(_context);
                LoteriasBLL loteriasBLL = new LoteriasBLL(_context);
                foreach (var jug in tk.Jugadas)
                {
                    TiposJugadas? tipoJugada = tiposJugadasBLL.Buscar(jug.TipoJugadaId);
                    Loterias? loteria = loteriasBLL.Buscar(tipoJugada.LoteriaId);
                    jug.LoteriaId = loteria.LoteriaId;
                    jug.LoteriaDescripcion = loteria.Descripcion;
                    jug.TipoJugadaDescripcion = tipoJugada.Descripcion;
                }
            }
            return tk;
        }
    }
}
