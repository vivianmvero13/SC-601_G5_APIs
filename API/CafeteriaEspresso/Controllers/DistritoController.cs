using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistritoController : Controller
    {
        private readonly DistritoService _distritoService;

        public DistritoController(DistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<DistritoModel>> GetDistritoModel()
        {
            return _distritoService.GetDistritoModel();
        }

        [HttpGet("{id}")]
        public ActionResult<DistritoModel> GetById(int id)
        {
            return _distritoService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<DistritoModel> AddG5_Distrito(DistritoModel distritoModel)
        {

            var newDistritoModel = _distritoService.AddG5_Distrito(distritoModel);

            return
                CreatedAtAction(
                        nameof(GetDistritoModel), new
                        {
                            id = newDistritoModel.id,
                        },
                        newDistritoModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateDistrito(DistritoModel distritoModel)
        {

            if (!_distritoService.UpdateG5_Distrito(distritoModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El distrito no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteDistritoModel(int id)
        {

            if (!_distritoService.DeleteG5_Distrito(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El distrito no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

    }
}
