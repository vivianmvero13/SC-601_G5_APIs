using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResenasController : Controller
    {
        private readonly ResenasService _resenasService;

        public ResenasController(ResenasService resenasService)
        {
            _resenasService = resenasService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<ResenasModel>> GetResenasModel()
        {
            return _resenasService.GetResenasModel();
        }

        [HttpGet("{id}")]
        public ActionResult<ResenasModel> GetById(int id)
        {
            return _resenasService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ResenasModel> AddG5_Resenas(ResenasModel resenasModel)
        {

            var newResenasModel = _resenasService.AddG5_Resenias(resenasModel);

            return
                CreatedAtAction(
                        nameof(GetResenasModel), new
                        {
                            id = newResenasModel.id,
                        },
                        newResenasModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateResenas(ResenasModel resenasModel)
        {

            if (!_resenasService.UpdateG5_Resenias(resenasModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La reseña no está"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteResenasModel(int id)
        {

            if (!_resenasService.DeleteG5_Resenias(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La reseña no está"
                        }
                    );
            }

            return NoContent();

        }

    }
}
