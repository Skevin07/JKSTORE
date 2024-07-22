//ESTE CONTROLADOR SIRVE PARA GESTIONAR LAS VIEWS Y LOS FLOJOS QUE VAN HACIA LA BD//
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
              
        //Vista que muestra todos los documentos de la coleccion//
            public async Task<IActionResult> IndexCliente()=> View(await _clienteService.GetAsync()); //Vista que permite ver todo el documento//

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

        [HttpPost] //Guardar documentos en la base con metodo post//
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid) //si el modelo no es valido//
            {
                return View(cliente);
            }
            await _clienteService.CreateAsync(cliente);
            return RedirectToAction(nameof(IndexCliente));

        }

        //Para editar un documento//
        public async Task<IActionResult> Edit(string id)
        {
            var cliente = await _clienteService.GetAsync(id);
            if (cliente == null) 
            { 
                 return NotFound();
            }
            return View(cliente);
        }

        [HttpPut] //Metodo para modificar PUT//
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            await _clienteService.UpdateAsync(id, cliente);
            return RedirectToAction(nameof(IndexCliente));
        }

        //Para eliminar un documento//
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
            return RedirectToAction(nameof(IndexCliente));
        }


    }
}
