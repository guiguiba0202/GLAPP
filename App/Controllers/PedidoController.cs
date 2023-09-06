using GLAPP_API.Data;
using GLAPP_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GLAPP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private PedidoDBContext _context;
        public PedidoController(PedidoDBContext context) {
            _context = context;
        }

        [HttpGet("Select")]
        public ActionResult<List<Pedido>> BuscarTodosPedidos()
        {
            var pedidos = _context.tbPedidos.ToList();
            return pedidos;
        }

        [HttpPost("Create")]
        public ActionResult<Pedido> InserirPedido(Pedido pedido)
        {
            var p = _context.tbPedidos.Add(pedido);
            _context.SaveChanges();
            return Ok(p.Entity);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult<Pedido> DeletePedido(int id)
        {
            var pedido = _context.tbPedidos.Find(id);
            if (pedido == null)
            {
                Ok("Pedido removido");
            }
            _context.tbPedidos.Remove(pedido);
            _context.SaveChanges();
            return Ok("Pedido deletado");
        }
    }
}
