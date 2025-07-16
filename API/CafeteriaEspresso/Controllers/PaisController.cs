using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : Controller
    {
        private readonly PaisService _paisService;

        public PaisController(PaisService paisService)
        {
            _paisService = paisService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<PaisModel>> GetPaisModel()
        {
            return _paisService.GetPaisModel();
        }

        [HttpGet("{id}")]
        public ActionResult<PaisModel> GetById(int id)
        {
            return _paisService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<PaisModel> AddG5_Pais(PaisModel paisModel)
        {

            var newPaisModel = _paisService.AddG5_Pais(paisModel);

            return
                CreatedAtAction(
                        nameof(GetPaisModel), new
                        {
                            id = newPaisModel.id,
                        },
                        newPaisModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdatePais(PaisModel paisModel)
        {

            if (!_paisService.UpdateG5_Pais(paisModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El país no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeletePaisModel(int id)
        {

            if (!_paisService.DeleteG5_Pais(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El país no fue encontrado"
                        }
                    );
            }

            return NoContent();

        }

    }
}
