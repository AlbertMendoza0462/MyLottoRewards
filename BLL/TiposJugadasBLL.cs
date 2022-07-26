using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLotoRewards.BLL
{
    public class TiposJugadasBLL
    {
        private Context _context;
        public TiposJugadasBLL(Context context)
        {
            _context = context;
        }

		public bool Existe(int tipoJugadaID)
        {
            return _context.TiposJugadas.Any(tipoJugada => tipoJugada.TipoJugadaId == tipoJugadaID);
        }

        public bool Guardar(TiposJugadas tipoJugada)
        {
            return (!Existe(tipoJugada.TipoJugadaId)) ? Insertar(tipoJugada) : Modificar(tipoJugada);
        }

        public bool Insertar(TiposJugadas tipoJugada)
        {
            _context.TiposJugadas.Add(tipoJugada);

            return _context.SaveChanges() > 0;
        }

        public bool Modificar(TiposJugadas tipoJugada)
        {
            _context.Entry(tipoJugada).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(tipoJugada).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(TiposJugadas tipoJugada)
        {
            _context.Entry(tipoJugada).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public TiposJugadas? Buscar(int tipoJugadaId)
        {
            return _context.TiposJugadas
                .Where(p => p.TipoJugadaId == tipoJugadaId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<TiposJugadas> GetListByLoteria(int loteriaId)
        {
            return _context.TiposJugadas
                .Where(p => p.LoteriaId == loteriaId)
                .AsNoTracking()
                .ToList();
        }

        public List<TiposJugadas> GetList()
        {
            return _context.TiposJugadas
                .AsNoTracking()
                .ToList();
        }
    }
}
