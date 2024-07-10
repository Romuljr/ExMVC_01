using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

//Adicionar servi�os ao cont�iner
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseStaticFiles();

//Configurar rota padr�o
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default", //P�gina por padr�o
        pattern: "{controller=Home}/{action=Index}"
    );
});

app.Run();
