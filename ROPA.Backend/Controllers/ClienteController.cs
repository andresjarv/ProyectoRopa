using Microsoft.AspNetCore.Mvc;
using WebApi.ApiService.Entidades;
using WebApi.ApiService.Negocio;

namespace WebApi.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            var clientes = await _clienteService.ObtenerTodos();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _clienteService.ObtenerPorId(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Post(Cliente cliente)
        {    
            var nuevoCliente = await _clienteService.Crear(cliente);
            return CreatedAtAction(nameof(Get), new { id = nuevoCliente.Id }, nuevoCliente);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool eliminado = await _clienteService.Eliminar(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}


