using System.ComponentModel.DataAnnotations;

namespace MyLotoRewards.Models
{
    public class TiposJugadas
    {
        [Key]
        public int TipoJugadaId { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Elija la loteria."), Required]
        public int LoteriaId { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Digite la descripción."), Required]
        public string Descripcion { get; set; }
    }
}
