using System.ComponentModel.DataAnnotations;

namespace MyLotoRewards.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el nombre del usuario."), Required]
        public string Nombre { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el email del usuario."), Required]
        public string Email { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el UId del usuario."), Required]
        public string UserIdApi { get; set; }
    }
}
