using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLotoRewards.Models
{
    public class Ganancias
    {
        [Key]
        public int GananciaId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "La ganancia necesita un usuario."), Required]
        public int UsuarioId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Elija el tipo de jugada."), Required]
        public int TipoJugadaId { get; set; }
        [Range(1, Double.MaxValue, ErrorMessage = "El monto debe se mayor que 0."),  Required]
        public double Monto { get; set; }
        [Required(ErrorMessage = "Digite la fecha de la ganancia.")]
        public DateTime Fecha{ get; set; } = DateTime.Now;
        [NotMapped, Range(1, Int32.MaxValue, ErrorMessage = "Elija la loteria.")]
        public int LoteriaId { get; set; }
        [NotMapped]
        public string LoteriaDescripcion { get; set; }
        [NotMapped]
        public string TipoJugadaDescripcion { get; set; }
    }
}
