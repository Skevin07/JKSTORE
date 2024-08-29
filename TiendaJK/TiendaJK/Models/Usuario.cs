using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TiendaJK.Models
{
    public class Usuario
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
