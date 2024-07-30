//ESTE CONTROLADOR SIRVE PARA GESTIONAR LAS VIEWS Y LOS FLOJOS QUE VAN HACIA LA BD//
using TiendaJK.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TiendaJK.Models;



namespace TiendaJK.Controllers
{
    public class ClientesController : Controller
    {
        //Vista que permite ver todo el documento//
 private readonly ClienteService _clienteService;

        public ClientesController(ClienteService clienteService)
        {

            _clienteService = clienteService;

        }
              
        
            public async Task<IActionResult> Index()=> View(await _clienteService.GetAsync());
        public async Task<IActionResult> Details(string id) //Vista que permite ver un documento//
        {
                var cliente = await _clienteService.GetAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return View(cliente);
        }


        //Para crear un documento//
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


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("El ID del cliente es necesario.");
            }

            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Cliente cliente)
        {
            if (string.IsNullOrEmpty(id) || cliente == null || cliente.Id != id)
            {
                return BadRequest("Datos inválidos.");
            }

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
