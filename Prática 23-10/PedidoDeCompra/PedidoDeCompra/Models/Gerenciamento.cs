namespace PedidoDeCompra.Models
{
    public class Gerenciamento
    {
        public List<Produto> Solicitado { get; set; } = new List<Produto>();
        public List<Produto> Expedição { get; set; } = new List<Produto>();
        public List<Produto> Enviado { get; set; } = new List<Produto>();
    }
}
