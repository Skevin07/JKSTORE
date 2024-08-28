using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiendaJK.Models
{
    public class Carrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
