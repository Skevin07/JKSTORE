using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiendaJK.Models
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DUI { get; set; }
        public string Telefono { get; set; }
        public string correo { get; set; }
    }
}
