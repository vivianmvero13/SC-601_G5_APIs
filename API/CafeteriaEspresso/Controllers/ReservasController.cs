using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservasController : Controller
    {
        private readonly ReservasService _reservasService;

        public ReservasController(ReservasService reservasService)
        {
            _reservasService = reservasService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<ReservasModel>> GetReservasModel()
        {
            return _reservasService.GetReservasModel();
        }

        [HttpGet("{id}")]
        public ActionResult<ReservasModel> GetById(int id)
        {
            return _reservasService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ReservasModel> AddG5_Reservas(ReservasModel reservasModel)
        {

            var newReservasModel = _reservasService.AddG5_Reservas(reservasModel);

            return
                CreatedAtAction(
                        nameof(GetReservasModel), new
                        {
                            id = newReservasModel.id,
                        },
                        newReservasModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateG5_Resevas(ReservasModel reservasModel)
        {

            if (!_reservasService.UpdateG5_Reservas(reservasModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La reserva no esta"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteReservasModel(int id)
        {

            if (!_reservasService.DeleteG5_Reservas(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La reserva no esta"
                        }
                    );
            }

            return NoContent();

        }

    }
}
