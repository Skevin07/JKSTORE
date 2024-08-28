using TiendaJK.Models;
using TiendaJK.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuración de base de datos
builder.Services.Configure<DatabaseSettingscs>(
    builder.Configuration.GetSection("ConnectionStrings"));

// Registro de servicios
builder.Services.AddSingleton<ClienteService>();
builder.Services.AddScoped<ProductoService>(); // Registro de ProductoService
builder.Services.AddSingleton<CarritoService>(); // Registrar CarritoService

// Añadir controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del pipeline de HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
