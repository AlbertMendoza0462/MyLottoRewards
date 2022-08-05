using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLotoRewards.BLL
{
    public class GananciasBLL
    {
        private Context _context;
        public GananciasBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int gananciaID)
        {
            return _context.Ganancias.Any(ganancia => ganancia.GananciaId == gananciaID);
        }

        public bool Guardar(int usuarioId, Ganancias ganancia)
        {
            return (!Existe(ganancia.GananciaId)) ? Insertar(usuarioId, ganancia) : Modificar(usuarioId, ganancia);
        }

        public bool Insertar(int usuarioId, Ganancias ganancia)
        {
            UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
            var usuario = usuariosBLL.Buscar(usuarioId);
            usuario.TotalGanado += ganancia.Monto;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.Ganancias.Add(ganancia);

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ganancia).State = EntityState.Detached;
            _context.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }

        public bool Modificar(int usuarioId, Ganancias ganancia)
        {
            UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
            var usuario = usuariosBLL.Buscar(usuarioId);

            var gananciaAnterior = this.Buscar(usuarioId, ganancia.GananciaId);
            usuario.TotalGanado -= gananciaAnterior.Monto;
            usuario.TotalGanado += ganancia.Monto;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.Entry(ganancia).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ganancia).State = EntityState.Detached;
            _context.Entry(usuario).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(int usuarioId, Ganancias ganancia)
        {
            if (Existe(ganancia.GananciaId))
            {
                UsuariosBLL usuariosBLL = new UsuariosBLL(_context);
                var usuario = usuariosBLL.Buscar(usuarioId);
                usuario.TotalGanado -= ganancia.Monto;

                _context.Entry(usuario).State = EntityState.Modified;
                _context.Entry(ganancia).State = EntityState.Deleted;

                var elimino = _context.SaveChanges() > 0;
                _context.Entry(usuario).State = EntityState.Detached;
                return elimino;
            }
            else
            {
                return false;
            }
        }

        public Ganancias? Buscar(int usuarioId, int gananciaId)
        {
            var query = _context.Ganancias.AsQueryable();

            if (usuarioId > 0)
                query = query.Where(t => t.UsuarioId == usuarioId);

            query = query.Where(t => t.GananciaId == gananciaId)
                .AsNoTracking();

            var ganancia = query.SingleOrDefault();


            return (query != null) ? prepararInstancia(ganancia) : ganancia;
        }

        public List<Ganancias>? GetListFiltred(
            int usuarioId,
            DateTime fechaDesde,
            DateTime fechaHasta,
            int loteriaId,
            int tipoJugadaId,
            double montoDesde,
            double montoHasta
            )
        {
            var query = _context.Ganancias.AsQueryable();
            query = query.Where(g => g.UsuarioId == usuarioId);
            if (tipoJugadaId > 0)
                query = query.Where(g => g.TipoJugadaId == tipoJugadaId);
            if (montoDesde > 0)
                query = query.Where(g => montoDesde <= g.Monto && montoHasta >= g.Monto);

            query = query.Where(g => fechaDesde <= g.Fecha && fechaHasta >= g.Fecha)
                .AsNoTracking();

            List<Ganancias>? gananciasTmp = query.ToList();
            List<Ganancias>? ganancias = new List<Ganancias>();

            if (gananciasTmp != null && gananciasTmp.Count > 0)
            {
                foreach (var gn in gananciasTmp)
                {
                    prepararInstancia(gn);
                }
            }

            if (loteriaId > 0 && tipoJugadaId == 0)
            {
                foreach (var ganancia in gananciasTmp)
                {
                    if (loteriaId > 0 && ganancia.LoteriaId == loteriaId)
                    {
                        ganancias.Add(ganancia);
                    }
                }
            }
            else
            {
                ganancias = gananciasTmp;
            }

            return ganancias;
        }

        public List<Ganancias>? GetList(int usuarioId)
        {
            var query = _context.Ganancias.AsQueryable();

            if (usuarioId > 0)
                query = query.Where(t => t.UsuarioId == usuarioId);

            query = query.Where(t => t.UsuarioId == usuarioId)
                .AsNoTracking();

            var ganancias = query.ToList();

            if (ganancias != null && ganancias.Count > 0)
            {
                foreach (Ganancias gn in ganancias)
                {
                    prepararInstancia(gn);
                }
            }

            return ganancias;
        }

        private Ganancias prepararInstancia(Ganancias gn)
        {
            if (gn != null)
            {
                TiposJugadasBLL tiposJugadasBLL = new TiposJugadasBLL(_context);
                LoteriasBLL loteriasBLL = new LoteriasBLL(_context);
                TiposJugadas? tiposJugadas = tiposJugadasBLL.Buscar(gn.TipoJugadaId);
                Loterias? loteria = loteriasBLL.Buscar(tiposJugadas.LoteriaId);
                gn.LoteriaId = loteria.LoteriaId;
                gn.LoteriaDescripcion = loteria.Descripcion;
                gn.TipoJugadaDescripcion = tiposJugadas.Descripcion;
            }
            return gn;
        }
    }
}
