using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromocionesController : Controller
    {
        private readonly PromocionesService _promocionesService;

        public PromocionesController(PromocionesService promocionesService)
        {
            _promocionesService = promocionesService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<PromocionesModel>> GetPromocionesModel()
        {
            return _promocionesService.GetPromocionesModel();
        }

        [HttpGet("{id}")]
        public ActionResult<PromocionesModel> GetById(int id)
        {
            return _promocionesService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<PromocionesModel> AddG5_Promociones(PromocionesModel promocionesModel)
        {

            var newPromocionesModel = _promocionesService.AddG5_Promociones(promocionesModel);

            return
                CreatedAtAction(
                        nameof(GetPromocionesModel), new
                        {
                            id = newPromocionesModel.id,
                        },
                        newPromocionesModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdatePromociones(PromocionesModel promocionesModel)
        {

            if (!_promocionesService.UpdateG5_Promociones(promocionesModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La promocion no esta"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeletePromocionesModel(int id)
        {

            if (!_promocionesService.DeleteG5_Promociones(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La promocion no esta"
                        }
                    );
            }

            return NoContent();

        }

    }
}
