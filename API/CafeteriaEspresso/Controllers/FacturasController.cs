using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturasController : Controller
    {
        private readonly FacturasService _facturasService;


        public FacturasController(FacturasService facturasService)
        {
            _facturasService = facturasService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<FacturasModel>> GetFacturasModel()
        {
            return _facturasService.GetFacturasModel();
        }

        [HttpGet("{id}")]
        public ActionResult<FacturasModel> GetById(int id)
        {
            return _facturasService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<FacturasModel> AddG5_Facturas(FacturasModel facturasModel)
        {

            var newFacturasModel = _facturasService.AddG5_Facturas(facturasModel);

            return
                CreatedAtAction(
                        nameof(GetFacturasModel), new
                        {
                            id = newFacturasModel.id,
                        },
                        newFacturasModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateFacturas(FacturasModel facturasModel)
        {

            if (!_facturasService.UpdateG5_Facturas(facturasModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La factura no esta"
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteFacturasModel(int id)
        {

            if (!_facturasService.DeleteG5_Facturas(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "La factura no esta"
                        }
                    );
            }

            return NoContent();

        }

    }
}
