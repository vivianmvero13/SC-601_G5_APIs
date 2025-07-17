using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaProductosController : Controller
    {
        private readonly CategoriaProductosService _categoriaProductosService;

        public CategoriaProductosController(CategoriaProductosService categoriaProductosService)
        {
            _categoriaProductosService = categoriaProductosService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaProductosModel>> GetCategoriaProductosModel()
        {
            return _categoriaProductosService.GetCategoriaProductosModel();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoriaProductosModel> GetById(int id)
        {
            return _categoriaProductosService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<CategoriaProductosModel> AddG5_Categoria_Productos(CategoriaProductosModel categoriaProductosModel)
        {

            var newCategoriaProductosModel = _categoriaProductosService.AddG5_Categoria_Productos(categoriaProductosModel);

            return
                CreatedAtAction(
                        nameof(GetCategoriaProductosModel), new
                        {
                            id = newCategoriaProductosModel.id,
                        },
                        newCategoriaProductosModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateCategoriaProductos(CategoriaProductosModel categoriaProductosModel)
        {

            if (!_categoriaProductosService.UpdateG5_Categoria_Productos(categoriaProductosModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: La categoria no existe."
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteCategoriaProductosModel(int id)
        {

            if (!_categoriaProductosService.DeleteG5_Categoria_Productos(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El existe no existe."
                        }
                    );
            }

            return NoContent();

        }

    }
}