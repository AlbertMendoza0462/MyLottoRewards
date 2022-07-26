using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLotoRewards.Models
{
    public class Jugadas
    {
        [Key, Range(0, Int32.MaxValue, ErrorMessage = "El TicketId debe ser mayor o igual que 0.")]
        public int JugadaId { get; set; }
        [Required(ErrorMessage = "La jugada debe pertenecer a un ticket")]
        public int TicketId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Elija el tipo de jugada."), Required]
        public int TipoJugadaId { get; set; }

        [Range(1, Double.MaxValue, ErrorMessage = "El monto debe ser mayor que 0."), Required]
        public double Monto { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Digite los números de la jugada."), Required(ErrorMessage = "Digite los números de la jugada.")]
        public string Numeros { get; set; }
        [NotMapped, Range(1, Int32.MaxValue, ErrorMessage = "Elija la loteria.")]
        public int LoteriaId { get; set; }
        [NotMapped]
        public string LoteriaDescripcion { get; set; }
        [NotMapped]
        public string TipoJugadaDescripcion { get; set; }
    }
}
