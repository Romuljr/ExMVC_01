using ExMVC_01.Repository.Contracts;
using ExMVC_01.Repository.Entities;
using ExMVC_01.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddControllersWithViews();

// Ler a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ExMVC_01DB");

// Configurar a injeção de dependência para ClienteRepository
builder.Services.AddTransient(map => new ClienteRepository(connectionString));


var app = builder.Build();

// Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseStaticFiles();

// Configurar rota padrão
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default", // Página por padrão
        pattern: "{controller=Home}/{action=Index}"
    );
});

app.Run();
