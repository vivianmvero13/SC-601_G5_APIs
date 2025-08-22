using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;


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

        [HttpGet("Historial/{id_Usuario:int}")]
        public ActionResult<IEnumerable<FacturasModel>> GetHistorialPorUsuario(int id_Usuario)
        {
            return _facturasService.GetHistorialPorUsuario(id_Usuario);
        }


        [HttpGet("Historial")]
        public ActionResult<IEnumerable<FacturasModel>> GetHistorialAdmin(
        [FromQuery] string? desde,
        [FromQuery] string? hasta,
        [FromQuery] int? idUsuario,
        [FromQuery] int? idFactura)
        {
            DateOnly? d = ParseDateOnly(desde);
            DateOnly? h = ParseDateOnly(hasta);

            var list = _facturasService.BuscarFacturas(idUsuario, idFactura, d, h);
            return list;
        }

        private static DateOnly? ParseDateOnly(string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return null;

            // el input de <input type="date"> viene como yyyy-MM-dd
            if (DateOnly.TryParseExact(s, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out var date))
                return date;

            // fallback por si llega en otro formato válido
            if (DateOnly.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                return date;

            return null; // si es inválida, la ignoramos
        }

    }
}

