using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TiendaJK.Models;
using System.Threading.Tasks;

namespace TiendaJK.Services
{
    public class ConteoServices
    {
        private readonly IMongoCollection<Visita> _visitaCollection;

        public ConteoServices(IOptions<DatabaseSettingscs> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _visitaCollection = database.GetCollection<Visita>("VisitasConteo");
        }

        public async Task<Visita> ObtenerVisitasAsync()
        {
            var visita = await _visitaCollection.Find(v => true).FirstOrDefaultAsync();
            if (visita == null)
            {
                visita = new Visita { ConteoVisitas = 0 };
                await _visitaCollection.InsertOneAsync(visita);
            }
            return visita;
        }

        public async Task IncrementarVisitasAsync()
        {
            var visita = await ObtenerVisitasAsync();
            visita.ConteoVisitas++;
            var filter = Builders<Visita>.Filter.Eq(v => v.Id, visita.Id);
            await _visitaCollection.ReplaceOneAsync(filter, visita);
        }
    }
}
