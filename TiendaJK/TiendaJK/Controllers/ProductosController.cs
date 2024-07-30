using TiendaJK.Services;
using Microsoft.AspNetCore.Mvc;
using TiendaJK.Models;

namespace TiendaJK.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index() => View(await _productoService.GetAsync());

        public async Task<IActionResult> Details(string id)
        {
            var producto = await _productoService.GetAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }
            await _productoService.CreateAsync(producto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("El ID del producto es necesario.");
            }

            var producto = await _productoService.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Producto producto)
        {
            if (string.IsNullOrEmpty(id) || producto == null || producto.Id != id)
            {
                return BadRequest("Datos inválidos.");
            }

            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            await _productoService.UpdateAsync(id, producto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var producto = await _productoService.GetAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _productoService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
