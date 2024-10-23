using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PedidoDeCompra.Models
{
    public partial class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Fabricante { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Status")]
        public string? Statuss { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Vendedor")]
        public int? VendedorId { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string? Prioridade { get; set; }

        public virtual Vendedor? Vendedor { get; set; }
    }
}
