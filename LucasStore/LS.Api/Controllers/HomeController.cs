using Microsoft.AspNetCore.Mvc;

namespace LS.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        // [Route("clientes")]
        // [Route("clientes/2587")]
        // [Route("clientes/2587/pedidos")]
        public object Get()
        {
            return new { version = "Hello World" };
        }
    }
}