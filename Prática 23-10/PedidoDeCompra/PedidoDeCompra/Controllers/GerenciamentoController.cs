using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoDeCompra.Models;

namespace PedidoDeCompra.Controllers
{
    public class GerenciamentoController : Controller
    {
        private readonly dbPedidoContext _context;

        public GerenciamentoController(dbPedidoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.Produtos.Include(t => t.Vendedor).ToListAsync();

            var viewModel = new Gerenciamento
            {
                Solicitado = pedidos.Where(t => t.Statuss == "Solicitado").ToList(),
                Expedição = pedidos.Where(t => t.Statuss == "Expedição").ToList(),
                Enviado = pedidos.Where(t => t.Statuss == "Enviado").ToList(),
            };
            return View(viewModel);
        }
    }
}
