using System;
using System.Collections.Generic;

namespace PedidoDeCompra.Models
{
    public partial class Vendedor
    {
        public Vendedor()
        {
            Produtos = new HashSet<Produto>();
        }

        public int VendedorId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
