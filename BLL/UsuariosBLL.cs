using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLotoRewards.BLL
{
    public class UsuariosBLL
    {
        private Context _context;
        public UsuariosBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int usuarioID)
        {
            return _context.Usuarios.Any(usuario => usuario.UsuarioId == usuarioID);
        }

        public bool Guardar(Usuarios usuario)
        {
            return (!Existe(usuario.UsuarioId)) ? Insertar(usuario) : Modificar(usuario);
        }

        public bool Insertar(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);

            return _context.SaveChanges() > 0;
        }

        public bool Modificar(Usuarios usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(Usuarios usuario)
        {
            _context.Entry(usuario).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public Usuarios? Buscar(int usuarioId)
        {
            var usuario = _context.Usuarios
                .Where(p => p.UsuarioId == usuarioId)
                .AsNoTracking()
                .SingleOrDefault();
            usuario.Balance = usuario.TotalGanado - usuario.TotalInvertido;
            return usuario;
        }

        public Usuarios? BuscarPorUserIdApi(string userIdApi)
        {
            var usuario = _context.Usuarios
                .Where(p => p.UserIdApi == userIdApi)
                .AsNoTracking()
                .SingleOrDefault();

            if(usuario != null)
                usuario.Balance = usuario.TotalGanado - usuario.TotalInvertido;

            return usuario;
        }

        public Usuarios? BuscarPorEmail(string email)
        {
            var usuario = _context.Usuarios
                .Where(u => u.Email == email)
                .AsNoTracking()
                .SingleOrDefault();

            usuario.Balance = usuario.TotalGanado - usuario.TotalInvertido;
            return usuario;
        }

        public List<Usuarios>? GetList()
        {
            var usuarios = _context.Usuarios
                .AsNoTracking()
                .ToList();
            foreach (var us in usuarios)
            {
                us.Balance = us.TotalGanado - us.TotalInvertido;
            }
            return usuarios;
        }

        public List<Standing>? GetWinners()
        {
            var usuarios = _context.Winners
                .AsNoTracking()
                .ToList();
            return usuarios.Cast<Standing>().ToList();
        }

        public List<Standing>? GetLosers()
        {
            var usuarios = _context.Losers
                .AsNoTracking()
                .ToList();
            return usuarios.Cast<Standing>().ToList();
        }

        public double[] GetDashBoardData(int usuarioId)
        {
            double[] dashboardData = new double[6];
            TicketsBLL ticketsBLL = new TicketsBLL(_context);
            GananciasBLL gananciasBLL = new GananciasBLL(_context);

            var tickets = ticketsBLL.GetList(usuarioId);
            var ganancias = gananciasBLL.GetList(usuarioId);

            int cantJugadas = 0;
            foreach (var ticket in tickets)
            {
                cantJugadas += ticket.Jugadas.Count;
            }

            dashboardData[0] = tickets.Count;
            dashboardData[1] = cantJugadas;
            dashboardData[2] = ganancias.Count;
            dashboardData[3] = tickets.Sum(t => t.Total);
            dashboardData[4] = ganancias.Sum(g => g.Monto);
            dashboardData[5] = dashboardData[4] - dashboardData[3];


            return dashboardData;
        }
    }
}
