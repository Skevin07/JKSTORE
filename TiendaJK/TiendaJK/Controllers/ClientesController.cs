using TiendaJK.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TiendaJK.Models;

namespace TiendaJK.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteService _clienteService;
        public ClientesController(ClienteService clienteService)
        {


            _clienteService = clienteService;
        }
              
            public async Task<IActionResult> Index()=> View(await _clienteService.GetAsync());

            public async Task<IActionResult> Details(string id)
            {
                var cliente = await _clienteService.GetAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
            }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            await _clienteService.CreateAsync(cliente);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null) 
            { 
            return NotFound();
            }
            return View(cliente);

        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            await _clienteService.UpdateAsync(id, cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _clienteService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
