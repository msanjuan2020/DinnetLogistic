using Dinet.Application.Interfaces;
using Microsoft.Data.SqlClient;
using Dinet.Infrastructure.Repositories;
using Dinet.Application.Usecases;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();


builder.Services.AddTransient<SqlConnection>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");


    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("La cadena de conexión no está configurada correctamente.");
    }

    return new SqlConnection(connectionString);
});


builder.Services.AddTransient<IMovInventarioRepository, MovInventarioRepository>();

// controllers
// Registrar el caso de uso GetMovInventarios
builder.Services.AddTransient<GetMovInventarios>();

var app = builder.Build();

// Configurar el HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
