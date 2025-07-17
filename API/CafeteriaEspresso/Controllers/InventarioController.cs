using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : Controller
    {
        private readonly InventarioService _inventarioService;

        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<InventarioModel>> GetInventarioModel()
        {
            return _inventarioService.GetInventarioModel();
        }

        [HttpGet("{id}")]
        public ActionResult<InventarioModel> GetById(int id)
        {
            return _inventarioService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<InventarioModel> AddG5_Inventario(InventarioModel inventarioModel)
        {

            var newInventarioModel = _inventarioService.AddG5_Inventario(inventarioModel);

            return
                CreatedAtAction(
                        nameof(GetInventarioModel), new
                        {
                            id = newInventarioModel.id,
                        },
                        newInventarioModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateInventario(InventarioModel inventarioModel)
        {

            if (!_inventarioService.UpdateG5_Inventario(inventarioModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El inventario no existe."
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteInventarioModel(int id)
        {

            if (!_inventarioService.DeleteG5_Inventario(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El inventario no existe."
                        }
                    );
            }

            return NoContent();

        }

    }
}

