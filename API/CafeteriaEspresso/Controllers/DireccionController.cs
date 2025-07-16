using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DireccionController : Controller
    {
        private readonly DireccionService _direccionService;

        public DireccionController(DireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<DireccionModel>> GetDireccionModel()
        {
            return _direccionService.GetDireccionModel();
        }

        [HttpGet("{id}")]
        public ActionResult<DireccionModel> GetById(int id)
        {
            return _direccionService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<DireccionModel> AddG5_Direccion(DireccionModel direccionModel)
        {

            var newDireccionModel = _direccionService.AddG5_Direccion(direccionModel);

            return
                CreatedAtAction(
                        nameof(GetDireccionModel), new
                        {
                            id = newDireccionModel.id,
                        },
                        newDireccionModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateDireccion(DireccionModel direccionModel)
        {

            if (!_direccionService.UpdateG5_Direccion(direccionModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La direccion no fue encontrada"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteDireccionModel(int id)
        {

            if (!_direccionService.DeleteG5_Direccion(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La direccion no fue encontrada"
                        }
                    );
            }

            return NoContent();

        }

    }
}
