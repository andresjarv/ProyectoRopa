using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorTiendaRopa.Entidades;
using System.Text.Json;

namespace BlazorTiendaRopa.Negocio
{
    public class ClienteNegocio
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl = "https://localhost:7593/Cliente";
        private readonly ILogger<ClienteNegocio> _logger;

        public ClienteNegocio(HttpClient httpClient, ILogger<ClienteNegocio> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Cliente>> ListarClientes()
        {
            Console.WriteLine("ClienteNegocio.ListarClientes() llamado.");
            try
            {

                var response = await _httpClient.GetAsync($"{_baseApiUrl}/listar");
                Console.WriteLine($"Respuesta de listar Clientes: Status Code - {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var clientes = JsonSerializer.Deserialize<List<Cliente>>(content, options);
                    Console.WriteLine($"Materias Clientes exitosamente: {clientes?.Count ?? 0} encontradas.");
                    return clientes;
                }
                else
                {
                    Console.WriteLine($"Error al listar Cliente: Status Code - {response.StatusCode}");
                    return null; // O lanza una excepción más específica
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar clientes: {ex.Message}");
                return null; // O lanza una excepción más específica
            }
        }

        public async Task<bool> GuardarCliente(Cliente cliente)
        {
            cliente.Id = 11;
            cliente.Correo = "no";
            try
            {
                _logger.LogInformation($"Iniciando la llamada para guardar la cliente: {JsonSerializer.Serialize(cliente)}");
                var response = await _httpClient.PostAsJsonAsync($"{_baseApiUrl}/nuevo", cliente);
                _logger.LogInformation($"Respuesta de guardar cliente: Status Code - {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al guardar materia: {ex.Message}");
                return false; // O lanza una excepción más específica
            }
        }

        public async Task<bool> ActualizarCliente(Cliente cliente)
        {
            try
            {
                _logger.LogInformation($"Iniciando la llamada para actualizar la cliente: {JsonSerializer.Serialize(cliente)}");
                var response = await _httpClient.PutAsJsonAsync($"{_baseApiUrl}/actualizar", cliente);
                _logger.LogInformation($"Respuesta de actualizar cliente: Status Code - {response.StatusCode}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar cliente: {ex.Message}");
                return false; // O lanza una excepción más específica
            }
        }
    }
}
