using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : Controller
    {
        private readonly ProductosService _ProductosService;

        public ProductosController(ProductosService ProductosService)
        {
            _ProductosService = ProductosService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<ProductosModel>> GetProductosModel()
        {
            return _ProductosService.GetProductosModel();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductosModel> GetById(int id)
        {
            return _ProductosService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ProductosModel> AddG5_Productos(ProductosModel ProductosModel)
        {

            var newProductosModel = _ProductosService.AddG5_Productos(ProductosModel);

            return
                CreatedAtAction(
                        nameof(GetProductosModel), new
                        {
                            id = newProductosModel.id,
                        },
                        newProductosModel);

        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateProductos(int id, [FromBody] ProductosModel ProductosModel)
        {
            if (id != ProductosModel.id)
            {
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el del cuerpo." });
            }

            if (!_ProductosService.UpdateG5_Productos(ProductosModel))
            {
                return NotFound(new { mensaje = "ERROR: El producto no existe." });
            }

            return NoContent();
        }


        
        [HttpDelete("{id}")]
        public IActionResult DeleteProductosModel(int id)
        {
            if (!_ProductosService.DeleteG5_Productos(id))
            {
                return NotFound(new { mensaje = "ERROR: El producto no existe." });
            }

            return NoContent();
        }


    }
}