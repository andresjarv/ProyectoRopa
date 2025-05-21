using Dapper;
using Microsoft.Data.SqlClient;
using WebApi.ApiService.Entidades;

public class ProductoService : IProductoService
{
    private readonly string _connectionString;

    public ProductoService(string connectionString)
    {
        _connectionString = connectionString;
    }

    private SqlConnection dbConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public async Task<List<Producto>> ObtenerTodos()
    {
        string sql = "SELECT * FROM Productos";
        using var db = dbConnection();
        var productos = await db.QueryAsync<Producto>(sql);
        return productos.ToList();
    }

    public async Task<Producto> ObtenerPorID(int id)
    {
        string sql = "SELECT * FROM Productos WHERE Id = @Id";
        using var db = dbConnection();
        return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { Id = id });
    }

    public async Task Agregar(Producto producto)
    {
        string sql = @"
            INSERT INTO Productos (Nombre, Precio, Stock)
            VALUES (@Nombre, @Precio, @Stock);";

        using var db = dbConnection();
        await db.ExecuteAsync(sql, new
        {
            producto.Nombre,
            producto.Precio,
            producto.Stock
        });
    }

    public async Task<bool> Eliminar(int id)
    {
        string sql = "DELETE FROM Productos WHERE Id = @Id";
        using var db = dbConnection();
        var filasAfectadas = await db.ExecuteAsync(sql, new { Id = id });
        return filasAfectadas > 0;
    }
}

