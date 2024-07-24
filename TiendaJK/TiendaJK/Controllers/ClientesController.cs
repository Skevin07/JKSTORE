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
            public async Task<IActionResult> Index()=> View(await _clienteService.GetAsync()); //Vista que permite ver todo el documento//

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
            return RedirectToAction(nameof(Index));

        }


        //Parte de la funcion editar pero lo que hace esta funcion en especifico es agarrar los datos de la bs y los muestra nada mas//
        public async Task<IActionResult> Edit (string id) 
        {
            var cliente = await _clienteService.GetAsync(id); //Linea de codigo para buscar el ID del padre//
            if (cliente == null) 
            { 
                 return NotFound(); //Si este no encuentra el ID osea que porque es nulo, entonces se mostrara como pagina no encontrada//
            }
            return View(cliente); //Para mostrar ese cliente//
        }


        [HttpPut] //Metodo para modificar PUT// //Es en esta funcion en especifico que hace que los datos se actualicen //
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
            return RedirectToAction(nameof(Index));
        }


    }
}
