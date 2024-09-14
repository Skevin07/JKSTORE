using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TiendaJK.Models
{
    public class Visita
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public int ConteoVisitas { get; set; }
    }

}
