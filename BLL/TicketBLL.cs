using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

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

        public bool Guardar(Tickets ticket)
        {
            return (!Existe(ticket.TicketId)) ? Insertar(ticket) : Modificar(ticket);
        }

        public bool Insertar(Tickets ticket)
        {
            _context.Tickets.Add(ticket);

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ticket).State = EntityState.Detached;
            return guardo;
        }

        public bool Modificar(Tickets ticket)
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM Jugadas WHERE TicketId={ticket.TicketId};");

			foreach (var item in ticket.Jugadas)
			{
                _context.Entry(item).State = EntityState.Added;
			}

            _context.Entry(ticket).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ticket).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(Tickets ticket)
        {
            if (Existe(ticket.TicketId))
			{
                _context.Database.ExecuteSqlRaw($"DELETE FROM Jugadas WHERE TicketId={ticket.TicketId};");

                _context.Entry(ticket).State = EntityState.Deleted;

                return _context.SaveChanges() > 0;
			}
			else
			{
                return false;
			}

        }

        public Tickets? Buscar(int ticketId)
        {
            var tk = _context.Tickets
                .Where(t => t.TicketId == ticketId)
                .Include(t => t.Jugadas)
                .AsNoTracking()
                .SingleOrDefault();
			
            return (tk != null) ? prepararInstancia(tk) : tk;
        }

        /*
        public List<Tickets>? GetListFiltred(
            DateTime fechaDesde, DateTime fechaHasta, string loteria, string tipoJugada, double montoDesde, double montoHasta
            )
        {
            return _context.Tickets
                .Where(t => 
                        (fechaDesde <= t.Fecha && fechaHasta >= t.Fecha) &&
                        (montoDesde <= t.Monto && montoHasta >= t.Monto) &&
                        t.Loteria.Contains(loteria) &&
                        t.TipoJugada.Contains(tipoJugada)
                    )
                .AsNoTracking()
                .ToList();
        }
        */

        public List<Tickets>? GetList()
        {
            List<Tickets> tickets = _context.Tickets
                .AsNoTracking()
                .ToList();

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
