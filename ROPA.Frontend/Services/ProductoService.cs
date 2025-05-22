using ROPA.Frontend.Models;
using System.Net.Http.Json;

namespace ROPA.Frontend.Services
{
    public class ProductoService : IProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Producto>> ObtenerProductos()
        {
            return await _http.GetFromJsonAsync<List<Producto>>("https://localhost:5001/api/Producto");
        }

        public async Task<Producto> ObtenerProducto(int id)
        {
            return await _http.GetFromJsonAsync<Producto>($"https://localhost:5001/api/Producto/{id}");
        }

        public async Task<bool> CrearProducto(Producto producto)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:5001/api/Producto", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ActualizarProducto(Producto producto)
        {
            var response = await _http.PutAsJsonAsync($"https://localhost:5001/api/Producto/{producto.Id}", producto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarProducto(int id)
        {
            var response = await _http.DeleteAsync($"https://localhost:5001/api/Producto/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
