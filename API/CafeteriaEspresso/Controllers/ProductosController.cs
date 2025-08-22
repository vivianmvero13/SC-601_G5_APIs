using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase // ControllerBase para API pura
    {
        private readonly ProductosService _productosService;

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        // GET /Productos?categoriaId=3&q=capuccino   (si no mandas params, devuelve todos)
        [HttpGet]
        public ActionResult<IEnumerable<ProductosModel>> Get(
            [FromQuery] int? categoriaId,
            [FromQuery(Name = "q")] string? nombre)
        {
            if (categoriaId.HasValue || !string.IsNullOrWhiteSpace(nombre))
                return Ok(_productosService.Buscar(categoriaId, nombre));

            return Ok(_productosService.GetProductosModel());
        }

        // GET /Productos/5
        [HttpGet("{id:int}")]
        public ActionResult<ProductosModel> GetById(int id)
        {
            var prod = _productosService.GetById(id);
            return prod is null ? NotFound() : Ok(prod);
        }

        // POST /Productos
        [HttpPost]
        public ActionResult<ProductosModel> AddG5_Productos([FromBody] ProductosModel model)
        {
            var creado = _productosService.AddG5_Productos(model);
            return CreatedAtAction(nameof(GetById), new { id = creado.id }, creado);
        }

        // PUT /Productos/5
        [HttpPut("{id:int}")]
        public IActionResult UpdateProductos(int id, [FromBody] ProductosModel model)
        {
            if (id != model.id)
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el del cuerpo." });

            return _productosService.UpdateG5_Productos(model) ? NoContent() : NotFound(new { mensaje = "ERROR: El producto no existe." });
        }

        // DELETE /Productos/5
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProductosModel(int id)
        {
            return _productosService.DeleteG5_Productos(id) ? NoContent() : NotFound(new { mensaje = "ERROR: El producto no existe." });
        }
    }
}
