using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Proyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadosController : Controller
    {
        private readonly EstadosService _estadosService;

        public EstadosController(EstadosService estadosService)
        {
            _estadosService = estadosService;
        }

        //Apis GET, POST, PUT y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<EstadosModel>> GetEstados()
        {
            return _estadosService.GetEstados();
        }

        [HttpGet("{id}")]
        public ActionResult<EstadosModel> GetById(int id)
        {
            return _estadosService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<EstadosModel> AddEstados(EstadosModel estados)
        {
            var newEstados = _estadosService.AddEstados(estados);

            return CreatedAtAction(
                nameof(GetEstados), new
                {
                    id = newEstados.id,
                },
                newEstados);
        }

        //Apis PUT
        [HttpPut]
        public IActionResult UpdateEstados(EstadosModel estados)
        {
            if (!_estadosService.UpdateEstados(estados))
            {
                return NotFound(new
                {
                    mensaje = "El estado no está"
                });
            }

            return NoContent();
        }

        //Apis DELETE
        [HttpDelete]
        public IActionResult DeleteEstados(int id)
        {
            if (!_estadosService.DeleteEstados(id))
            {
                return NotFound(new
                {
                    mensaje = "El estado no está"
                });
            }

            return NoContent();
        }

    }
}
