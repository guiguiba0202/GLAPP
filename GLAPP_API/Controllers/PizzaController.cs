using GLAPP_API.Data;
using GLAPP_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GLAPP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private PedidoDBContext _context;
        public PizzaController(PedidoDBContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<PizzaModel>> BuscarTodasPizzas()
        {
            var pizzas = _context.tbPizzas.ToList();
            return pizzas;
        }

        [HttpPost("Create")]
        public ActionResult<PizzaModel> InserirPizza(PizzaModel pizza)
        {
            var p = _context.tbPizzas.Add(pizza);
            _context.SaveChanges();
            return Ok(p.Entity);
        }

        [HttpDelete("Delete")]
        public ActionResult<PizzaModel> DeletePizza(int id)
        {
            var pizza = _context.tbPizzas.Find(id);
            if (pizza == null)
            {
                Ok("Pizza removida");
            }
            _context.tbPizzas.Remove(pizza);
            _context.SaveChanges();
            return Ok("Pizza deletada");
        }
    }
}
