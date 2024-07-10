using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

//Adicionar serviços ao contêiner
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Configurar o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseStaticFiles();

//Configurar rota padrão
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default", //Página por padrão
        pattern: "{controller=Home}/{action=Index}"
    );
});

app.Run();
