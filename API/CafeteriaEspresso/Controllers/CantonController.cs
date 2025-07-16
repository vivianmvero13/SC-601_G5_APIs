using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CantonController : Controller
    {
        private readonly CantonService _cantonService;

        public CantonController(CantonService cantonService)
        {
            _cantonService = cantonService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<CantonModel>> GetCantonModel()
        {
            return _cantonService.GetCantonModel();
        }

        [HttpGet("{id}")]
        public ActionResult<CantonModel> GetById(int id)
        {
            return _cantonService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<CantonModel> AddG5_Canton(CantonModel cantonModel)
        {

            var newCantonModel = _cantonService.AddG5_Canton(cantonModel);

            return
                CreatedAtAction(
                        nameof(GetCantonModel), new
                        {
                            id = newCantonModel.id,
                        },
                        newCantonModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateCanton(CantonModel cantonModel)
        {

            if (!_cantonService.UpdateG5_Canton(cantonModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El canton no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteCantonModel(int id)
        {

            if (!_cantonService.DeleteG5_Canton(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El canton no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

    }
}
