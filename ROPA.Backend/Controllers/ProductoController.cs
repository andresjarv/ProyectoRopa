using Microsoft.AspNetCore.Mvc;
using WebApi.ApiService.Entidades;
using WebApi.ApiService.Negocio;

namespace WebApi.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await _productoService.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var producto = await _productoService.ObtenerPorID(id);
            return producto == null ? NotFound() : Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            await _productoService.Agregar(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool eliminado = await _productoService.Eliminar(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}


