using System.ComponentModel.DataAnnotations;

namespace MyLotoRewards.Models
{
    public class Loterias
    {
        [Key]
        public int LoteriaId { get; set; }
        [StringLength(Int32.MaxValue, MinimumLength = 1, ErrorMessage = "Digite la descripción."), Required]
        public string Descripcion { get; set; }
    }
}
