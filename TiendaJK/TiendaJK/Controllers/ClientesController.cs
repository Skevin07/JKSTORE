using Microsoft.AspNetCore.Mvc;

namespace TiendaJK.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
