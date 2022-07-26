using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLotoRewards.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "El ticket necesita un usuario."), Required]
        public int UsuarioId { get; set; }
        [MinLength(1, ErrorMessage = "Un ticket necesita jugadas."), ForeignKey("TicketId"), Required]
        public List<Jugadas> Jugadas { get; set; } = new List<Jugadas>();
        [Required(ErrorMessage = "Digite la fecha del ticket.")]
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
