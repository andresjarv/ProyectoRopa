using ROPA.Frontend.Models;
namespace ROPA.Frontend.Services
{
    public interface IProductoService
    {
        Task<List<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProducto(int id);
        Task<bool> CrearProducto(Producto producto);
        Task<bool> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int id);
    }
}
