using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TiendaJK.Models;

namespace TiendaJK.Services
{
    public class UsuarioService
    {

        private readonly IMongoCollection<Usuario> _varr;

        public UsuarioService(IOptions<DatabaseSettingscs> settings)
        {
            var producto = new MongoClient(settings.Value.ConnectionString);
            var database = producto.GetDatabase(settings.Value.DatabaseName);
            _varr = database.GetCollection<Usuario>("Usuarios");
        }

        public async Task<List<Usuario>> GetAsync() =>
        await _varr.Find(_ => true).ToListAsync();

        public async Task<Usuario> GetAsync(string id) =>
            await _varr.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Usuario> GetByIdAsync(string id) =>
            await _varr.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuario newUsuario) =>
            await _varr.InsertOneAsync(newUsuario);

        public async Task UpdateAsync(string id, Usuario actualizarUsuario) =>
            await _varr.ReplaceOneAsync(x => x.Id == id, actualizarUsuario);

        public async Task RemoveAsync(string id) =>
            await _varr.DeleteOneAsync(x => x.Id == id);



    }
}
