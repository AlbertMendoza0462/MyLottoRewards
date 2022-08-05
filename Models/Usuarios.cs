using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLotoRewards.Models
{
    public class Usuarios
    {
        [Key, Range(0, Int32.MaxValue, ErrorMessage = "El Id no puede ser menor que 0.")]
        public int UsuarioId { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el nombre del usuario."), Required]
        public string Nombre { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el email del usuario."), Required]
        public string Email { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Falta el UId del usuario."), Required]
        public string UserIdApi { get; set; }
        public double TotalGanado { get; set; }
        public double TotalInvertido { get; set; }
        [NotMapped]
        public double Balance { get; set; }
    }
}
