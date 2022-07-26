using MyLotoRewards.DAL;
using MyLotoRewards.Models;
using Microsoft.EntityFrameworkCore;

namespace MyLotoRewards.BLL
{
    public class LoteriasBLL
    {
        private Context _context;
        public LoteriasBLL(Context context)
        {
            _context = context;
        }

        public bool Existe(int loteriaID)
        {
            return _context.Loterias.Any(loteria => loteria.LoteriaId == loteriaID);
        }

        public bool Guardar(Loterias loteria)
        {
            return (!Existe(loteria.LoteriaId)) ? Insertar(loteria) : Modificar(loteria);
        }

        public bool Insertar(Loterias loteria)
        {
            _context.Loterias.Add(loteria);

            return _context.SaveChanges() > 0;
        }

        public bool Modificar(Loterias loteria)
        {
            _context.Entry(loteria).State = EntityState.Modified;

            var guardo = _context.SaveChanges() > 0;
            _context.Entry(loteria).State = EntityState.Detached;
            return guardo;
        }

        public bool Eliminar(Loterias loteria)
        {
            _context.Entry(loteria).State = EntityState.Deleted;

            return _context.SaveChanges() > 0;
        }

        public Loterias? Buscar(int loteriaId)
        {
            return _context.Loterias
                .Where(p => p.LoteriaId == loteriaId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Loterias>? GetList()
        {
            return _context.Loterias
                .AsNoTracking()
                .ToList();
        }
    }
}
