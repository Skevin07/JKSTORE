using TiendaJK.Models;
using TiendaJK.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettingscs>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<ClienteService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddSingleton<CarritoService>();
builder.Services.AddSingleton<UsuarioService>();
builder.Services.AddSingleton<ConteoServices>();

builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
