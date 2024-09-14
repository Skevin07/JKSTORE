using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiendaJK.Models;
using System.Threading.Tasks;
using TiendaJK.Services;

namespace TiendaJK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConteoServices _conteoServices;

        public HomeController(ILogger<HomeController> logger, ConteoServices conteoServices)
        {
            _logger = logger;
            _conteoServices = conteoServices;
        }

        public async Task<IActionResult> Index()
        {
            
            if (HttpContext.Session.GetString("Visited") == null)
            {
                await _conteoServices.IncrementarVisitasAsync();
                HttpContext.Session.SetString("Visited", "true");
            }

            
            var visita = await _conteoServices.ObtenerVisitasAsync();
            ViewData["VisitaConteo"] = visita.ConteoVisitas;
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
