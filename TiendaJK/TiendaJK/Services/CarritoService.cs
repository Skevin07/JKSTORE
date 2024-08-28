using System.Collections.Generic;
using System.Linq;
using TiendaJK.Models;

namespace TiendaJK.Services
{
    public class CarritoService
    {
        private readonly List<Carrito> _items = new List<Carrito>();

        public IEnumerable<Carrito> GetItems() => _items;

        public void AddToCarrito(Producto producto)
        {
            var item = _items.FirstOrDefault(i => i.Producto.Id == producto.Id);
            if (item == null)
            {
                _items.Add(new Carrito
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }
            else
            {
                item.Cantidad++;
            }
        }

        public int GetTotalItems() => _items.Sum(i => i.Cantidad);

        public void ClearCarrito() => _items.Clear();
    }
}