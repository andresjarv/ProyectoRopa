using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ROPA.Frontend;
using ROPA.Frontend.Services;
using ROPA.Frontend.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7593") // URL del backend
});

builder.Services.AddScoped<IProductoService, ProductoService>();
//builder.Services.AddScoped<IClienteService, ClienteService>();

await builder.Build().RunAsync();