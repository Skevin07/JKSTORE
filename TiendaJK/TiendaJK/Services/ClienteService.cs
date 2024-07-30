using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TiendaJK.Models;

namespace TiendaJK.Services
{
    public class ClienteService
    {
        private readonly IMongoCollection<Cliente> _variable;

        public ClienteService(IOptions<DatabaseSettingscs> settings)
        {
            var cliente = new MongoClient(settings.Value.ConnectionString);
            var database = cliente.GetDatabase(settings.Value.DatabaseName);
            _variable = database.GetCollection<Cliente>("Clientes");

        }

        public async Task<List<Cliente>> GetAsync() =>
            await _variable.Find(_ => true).ToListAsync();

        public async Task<Cliente> GetAsync(string id) =>
            await _variable.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Cliente> GetByIdAsync(string id) =>
            await _variable.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente newCliente) =>
            await _variable.InsertOneAsync(newCliente);

        public async Task UpdateAsync(string id, Cliente actualizarCliente) =>
            await _variable.ReplaceOneAsync(x => x.Id == id, actualizarCliente);

        public async Task RemoveAsync(string id) =>
            await _variable.DeleteOneAsync(x => x.Id == id);
    }
}

