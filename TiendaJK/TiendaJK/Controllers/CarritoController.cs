using Microsoft.AspNetCore.Mvc;
using TiendaJK.Models;
using TiendaJK.Services;

namespace TiendaJK.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ProductoService _productoService;
        private static List<Carrito> _carrito = new List<Carrito>();

        public CarritoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            return View(_carrito);
        }

        public async Task<IActionResult> AddToCarrito(string id)
        {
            var producto = await _productoService.GetAsync(id);
            if (producto != null)
            {
                var carritoItem = _carrito.FirstOrDefault(c => c.Producto.Id == producto.Id);
                if (carritoItem != null)
                {
                    carritoItem.Cantidad++;
                }
                else
                {
                    _carrito.Add(new Carrito { Producto = producto, Cantidad = 1 });
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCarrito(string id)
        {
            var carritoItem = _carrito.FirstOrDefault(c => c.Producto.Id == id);
            if (carritoItem != null)
            {
                if (carritoItem.Cantidad > 1)
                {
                    carritoItem.Cantidad--;
                }
                else
                {
                    _carrito.Remove(carritoItem);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            return PartialView("_CheckoutModal");
        }
    }
}
