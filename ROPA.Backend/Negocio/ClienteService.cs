using Dapper;
using WebApi.ApiService.Entidades;
using Microsoft.Data.SqlClient;

namespace WebApi.ApiService.Negocio
{
    public class ClienteService : IClienteService
    {
        private readonly string _connectionString;

        public ClienteService(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection dbConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<Cliente>> ObtenerTodos()
        {
            string sql = "SELECT * FROM Clientes";
            using var db = dbConnection();
            return await db.QueryAsync<Cliente>(sql);
        }

        public async Task<Cliente> ObtenerPorId(int id)
        {
            string sql = "SELECT * FROM Clientes WHERE Id = @Id";
            using var db = dbConnection();
            return await db.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id });
        }

        public async Task<Cliente> Crear(Cliente cliente)
        {
            string sql = @"
            INSERT INTO Clientes (Nombre, Correo) 
            VALUES (@Nombre, @Correo);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using var db = dbConnection();
            var nuevoId = await db.QuerySingleAsync<int>(sql, new
            {
                cliente.Nombre,
                cliente.Correo
            });

            cliente.Id = nuevoId;
            return cliente;
        }

        public async Task<bool> Eliminar(int id)
        {
            string sql = "DELETE FROM Clientes WHERE Id = @Id";
            using var db = dbConnection();
            var filasAfectadas = await db.ExecuteAsync(sql, new { Id = id });
            return filasAfectadas > 0;
        }
    }

}


