using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleFacturaController : Controller
    {
        private readonly DetalleFacturaService _detalleFacturaService;

        public DetalleFacturaController(DetalleFacturaService detalleFacturaService)
        {
            _detalleFacturaService = detalleFacturaService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<DetalleFacturaModel>> GetDetalleFacturaModel()
        {
            return _detalleFacturaService.GetDetalleFacturaModel();
        }

        [HttpGet("{id}")]
        public ActionResult<DetalleFacturaModel> GetById(int id)
        {
            return _detalleFacturaService.GetById(id);
        }

        [HttpGet("Factura/{idFactura:int}")]
        public ActionResult<IEnumerable<DetalleFacturaModel>> GetByFactura(int idFactura)
        {
            return _detalleFacturaService.GetByFactura(idFactura);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<DetalleFacturaModel> AddG5_Detalle_Factura(DetalleFacturaModel detalleFacturaModel)
        {

            var newDetalleFacturaModel = _detalleFacturaService.AddG5_Detalle_Factura(detalleFacturaModel);

            return
                CreatedAtAction(
                        nameof(GetDetalleFacturaModel), new
                        {
                            id = newDetalleFacturaModel.id,
                        },
                        newDetalleFacturaModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateDetalleFactura(DetalleFacturaModel detalleFacturaModel)
        {

            if (!_detalleFacturaService.UpdateG5_Detalle_Factura(detalleFacturaModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: La categoria no existe."
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteDetalleFacturaModel(int id)
        {

            if (!_detalleFacturaService.DeleteG5_Detalle_Factura(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El existe no existe."
                        }
                    );
            }

            return NoContent();

        }

    }
}