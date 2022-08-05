namespace MyLotoRewards.Models
{
    public class Standing
    {
        public int Indice { get; set; }
        public int UsuarioId { get; set; }
        public double Balance { get; set; }
    }

    public class Winners : Standing
    {
    }

    public class Losers : Standing
    {
    }
}
