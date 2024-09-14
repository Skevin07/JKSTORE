using Microsoft.AspNetCore.Mvc;
using TiendaJK.Models;
using TiendaJK.Services;
using TiendaJK.ViewModel;

namespace TiendaJK.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        public async Task<IActionResult> Index() => View(await _usuarioService.GetAsync());



        public async Task<IActionResult> Details(string id)
        {
            var usuario = await _usuarioService.GetAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }



        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {


            if (!ModelState.IsValid)
            {
                return View(usuario);
            }
            await _usuarioService.CreateAsync(usuario);
            return RedirectToAction(nameof(Index));



            

            
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("El ID del Usuario es necesario.");
            }

            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Usuario usuario)
        {
            if (string.IsNullOrEmpty(id) || usuario == null || usuario.Id != id)
            {
                return BadRequest("Datos inválidos.");
            }

            if (!ModelState.IsValid)
            {
                return View(usuario);
            }

            await _usuarioService.UpdateAsync(id, usuario);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(string id)
        {
            var usuario = await _usuarioService.GetAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _usuarioService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Login()
        {
            

            return View();
        }


    }
}
