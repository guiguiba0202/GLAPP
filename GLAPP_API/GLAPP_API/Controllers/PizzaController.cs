using GLAPP_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GLAPP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PizzaModel>> BuscarTodasPizzas()
        {

            return Ok();
        }
    }
}
