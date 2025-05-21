using System.Collections.Generic;
using WebApi.ApiService.Entidades;

public interface IProductoService
{
    Task<List<Producto>> ObtenerTodos();
    Task<Producto> ObtenerPorID(int id);
    Task Agregar(Producto producto);
    Task<bool> Eliminar(int id);
}


