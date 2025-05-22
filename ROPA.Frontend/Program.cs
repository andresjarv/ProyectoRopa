using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ROPA.Frontend;
using ROPA.Frontend.Services;
using System.Net.Http;
using ROPA.Frontend.Components;
using ROPA.Frontend.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

// Agregar la configuración de HttpClient para consumir APIs
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var urlLocal = "https://localhost:7593";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlLocal) });
// Registrar los servicios que consumen las APIs
builder.Services.AddScoped<IProductoService, ProductoService>();
//builder.Services.AddScoped<IClienteService, ClienteService>();

await builder.Build().RunAsync();
