using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TiendaJK.ViewModel
{
    public class UsuarioVM
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string ConfirmarClave { get; set; }

    }
}
