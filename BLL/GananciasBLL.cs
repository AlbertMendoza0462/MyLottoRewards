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

        public bool Guardar(Ganancias ganancia)
        {
            return (!Existe(ganancia.GananciaId)) ? Insertar(ganancia) : Modificar(ganancia);
        }

        public bool Insertar(Ganancias ganancia)
        {
            _context.Ganancias.Add(ganancia);

            return _context.SaveChanges() > 0;
        }

        public bool Modificar(Ganancias ganancia)
        {
            _context.Entry(ganancia).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(ganancia).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(Ganancias ganancia)
        {
            _context.Entry(ganancia).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public Ganancias? Buscar(int gananciaId)
        {
            var gn = _context.Ganancias
                .Where(p => p.GananciaId == gananciaId)
                .AsNoTracking()
                .SingleOrDefault();

            return (gn != null) ? prepararInstancia(gn) : gn;
        }

        public List<Ganancias>? GetListFiltred(
            DateTime fechaDesde, DateTime fechaHasta, int tipoJugadaId, double montoDesde, double montoHasta
            )
        {
            return _context.Ganancias
                .Where(g =>
                        (fechaDesde <= g.Fecha && fechaHasta >= g.Fecha) &&
                        (montoDesde <= g.Monto && montoHasta >= g.Monto) &&
                        g.TipoJugadaId == tipoJugadaId
                    )
                .AsNoTracking()
                .ToList();
        }

        public List<Ganancias>? GetList()
        {
            List<Ganancias> ganancias = _context.Ganancias
                .AsNoTracking()
                .ToList();

            if (ganancias != null && ganancias.Count > 0)
			{
				foreach (var gn in ganancias)
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
