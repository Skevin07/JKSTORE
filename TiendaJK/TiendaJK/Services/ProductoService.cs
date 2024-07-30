using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TiendaJK.Models;


namespace TiendaJK.Services;

public class ProductoService
{
    private readonly IMongoCollection<Producto> _var;

    public ProductoService(IOptions<DatabaseSettingscs> settings)
    {
        var producto = new MongoClient(settings.Value.ConnectionString);
        var database = producto.GetDatabase(settings.Value.DatabaseName);
        _var = database.GetCollection<Producto>("Productos");
    }

    public async Task<List<Producto>> GetAsync() =>
        await _var.Find(_ => true).ToListAsync();

    public async Task<Producto> GetAsync(string id) =>
        await _var.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<Producto> GetByIdAsync(string id) =>
        await _var.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Producto newProducto) =>
        await _var.InsertOneAsync(newProducto);

    public async Task UpdateAsync(string id, Producto actualizarProducto) =>
        await _var.ReplaceOneAsync(x => x.Id == id, actualizarProducto);

    public async Task RemoveAsync(string id) =>
        await _var.DeleteOneAsync(x => x.Id == id);
}