using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProveedoresController : Controller
    {
        private readonly ProveedoresService _proveedoresService;

        public ProveedoresController(ProveedoresService proveedoresService)
        {
            _proveedoresService = proveedoresService;
        }

        //Apis GET, POST, PUT   y DELETE
        [HttpGet]
        public ActionResult<IEnumerable<ProveedoresModel>> GetProveedoresModel()
        {
            return _proveedoresService.GetProveedoresModel();
        }

        [HttpGet("{id}")]
        public ActionResult<ProveedoresModel> GetById(int id)
        {
            return _proveedoresService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ProveedoresModel> AddG5_Proveedores(ProveedoresModel proveedoresModel)
        {

            var newProveedoresModel = _proveedoresService.AddG5_Proveedores(proveedoresModel);

            return
                CreatedAtAction(
                        nameof(GetProveedoresModel), new
                        {
                            id = newProveedoresModel.id,
                        },
                        newProveedoresModel);

        }

        //APIS PUT
        [HttpPut]
        public IActionResult UpdateProveedores(ProveedoresModel proveedoresModel)
        {

            if (!_proveedoresService.UpdateG5_Proveedores(proveedoresModel))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El proveedor no fue encontrado."
                        }
                    );
            }

            return NoContent();

        }

        //APIS DELETE
        [HttpDelete]
        public IActionResult DeleteProveedoresModel(int id)
        {

            if (!_proveedoresService.DeleteG5_Proveedores(id))
            {
                return NotFound(
                        new
                        {
                            elmsneaje = "ERROR: El proveedor no fue encontrado."
                        }
                    );
            }

            return NoContent();

        }

    }
}