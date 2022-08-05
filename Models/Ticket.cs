using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLotoRewards.Models
{
    public class Tickets
    {
        [Key, Range(0, Int32.MaxValue, ErrorMessage = "El Id no puede ser menor que 0.")]
        public int TicketId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "El ticket necesita un usuario."), Required]
        public int UsuarioId { get; set; }
        [MinLength(1, ErrorMessage = "Un ticket necesita jugadas."), ForeignKey("TicketId"), Required]
        public List<Jugadas> Jugadas { get; set; } = new List<Jugadas>();
        [Required(ErrorMessage = "Digite la fecha del ticket.")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Range(1, Double.MaxValue, ErrorMessage = "El total debe ser mayor que 0."), Required]
        public double Total { get; set; }
    }
}
