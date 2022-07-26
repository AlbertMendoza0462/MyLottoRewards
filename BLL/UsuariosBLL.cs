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
            return _context.Usuarios
                .Where(p => p.UsuarioId == usuarioId)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public Usuarios? BuscarPorUserIdApi(string userIdApi)
        {
            return _context.Usuarios
                .Where(p => p.UserIdApi == userIdApi)
                .AsNoTracking()
                .SingleOrDefault();
        }

        public List<Usuarios>? GetList()
        {
            return _context.Usuarios
                .AsNoTracking()
                .ToList();
        }
    }
}
