using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiendaJK.Models
{
    public class Producto
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Estado { get; set; }
        
    }
}

