using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase 
    {
        private readonly ProductosService _productosService;

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductosModel>> Get(
            [FromQuery] int? categoriaId,
            [FromQuery(Name = "q")] string? nombre)
        {
            if (categoriaId.HasValue || !string.IsNullOrWhiteSpace(nombre))
                return Ok(_productosService.Buscar(categoriaId, nombre));

            return Ok(_productosService.GetProductosModel());
        }

        [HttpGet("{id:int}")]
        public ActionResult<ProductosModel> GetById(int id)
        {
            var prod = _productosService.GetById(id);
            return prod is null ? NotFound() : Ok(prod);
        }

        [HttpPost]
        public ActionResult<ProductosModel> AddG5_Productos([FromBody] ProductosModel model)
        {
            var creado = _productosService.AddG5_Productos(model);
            return CreatedAtAction(nameof(GetById), new { id = creado.id }, creado);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProductos(int id, [FromBody] ProductosModel model)
        {
            if (id != model.id)
                return BadRequest(new { mensaje = "Error en ID" });

            return _productosService.UpdateG5_Productos(model) ? NoContent() : NotFound(new { mensaje = "ERROR: El producto no existe." });
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProductosModel(int id)
        {
            return _productosService.DeleteG5_Productos(id) ? NoContent() : NotFound(new { mensaje = "ERROR: El producto no existe." });
        }
    }
}
