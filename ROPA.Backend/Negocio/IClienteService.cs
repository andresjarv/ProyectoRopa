public interface IClienteService
{
    Task<IEnumerable<Cliente>> ObtenerTodos();
    Task<Cliente> ObtenerPorId(int id);
    Task<Cliente> Crear(Cliente cliente);
    Task<bool> Eliminar(int id);
}

