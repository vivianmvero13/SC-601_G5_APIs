using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetodoPagoController : Controller
    {
        private readonly MetodoPagoService _metodoPagoService;

        public MetodoPagoController(MetodoPagoService metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<MetodoPagoModel>> GetMetodoPagoModel()
        {
            return _metodoPagoService.GetMetodoPagoModel();
        }

        [HttpGet("{id}")]
        public ActionResult<MetodoPagoModel> GetById(int id)
        {
            return _metodoPagoService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<MetodoPagoModel> AddG5_Metodo_Pago(MetodoPagoModel metodoPagoModel)
        {

            var newMetodoPagoModel = _metodoPagoService.AddG5_Metodo_Pago(metodoPagoModel);

            return
                CreatedAtAction(
                        nameof(GetMetodoPagoModel), new
                        {
                            id = newMetodoPagoModel.id,
                        },
                        newMetodoPagoModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateMetodoPago(MetodoPagoModel metodoPagoModel)
        {

            if (!_metodoPagoService.UpdateG5_Metodo_Pago(metodoPagoModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El metodo de pago no se encuentra"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteMetodoPagoModel(int id)
        {

            if (!_metodoPagoService.DeleteG5_Metodo_Pago(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "El metodo de pago no se encuentra"
                        }
                    );
            }

            return NoContent();

        }

    }
}
