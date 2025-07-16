using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinciaController : Controller
    {
        private readonly ProvinciaService _provinciaService;

        public ProvinciaController(ProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<ProvinciaModel>> GetProvinciaModel()
        {
            return _provinciaService.GetProvinciaModel();
        }

        [HttpGet("{id}")]
        public ActionResult<ProvinciaModel> GetById(int id)
        {
            return _provinciaService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ProvinciaModel> AddG5_Provincia(ProvinciaModel provinciaModel)
        {

            var newProvinciaModel = _provinciaService.AddG5_Provincia(provinciaModel);

            return
                CreatedAtAction(
                        nameof(GetProvinciaModel), new
                        {
                            id = newProvinciaModel.id,
                        },
                        newProvinciaModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateProvincia(ProvinciaModel provinciaModel)
        {

            if (!_provinciaService.UpdateG5_Provincia(provinciaModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La provincia no fue encontrada"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteProvinciaModel(int id)
        {

            if (!_provinciaService.DeleteG5_Provincia(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La provincia no fue encontrada"
                        }
                    );
            }

            return NoContent();

        }

    }
}
