using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradoresController : Controller
    {
        private readonly ColaboradoresService _colaboradoresService;
        public ColaboradoresController(ColaboradoresService colaboradoresService)
        {
            _colaboradoresService = colaboradoresService;
        }
        //Apis GET, POST, PUT   y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<ColaboradoresModel>> GetColaboradores()
        {
            return _colaboradoresService.GetColaboradores();

        }

        [HttpGet("{id}")]
        public ActionResult<ColaboradoresModel> GetById(int id)
        {
            return _colaboradoresService.GetById(id);
        }
        //Apis POST
        [HttpPost]
        public ActionResult<ColaboradoresModel> AddColaboradores(ColaboradoresModel colaboradores)
        {

            var newColaboradores = _colaboradoresService.AddColaboradores(colaboradores);

            return
                CreatedAtAction(
                        nameof(GetColaboradores), new
                        {
                            id = newColaboradores.id,
                        },
                        newColaboradores);

        }
        //Apis PUT
        [HttpPut]
        public IActionResult UpdateColaboradores(ColaboradoresModel colaboradores)
        {

            if (!_colaboradoresService.UpdateColaboradores(colaboradores))
            {
                return NotFound(
                        new
                        {
                            mensaje = "El Colaborador no esta"
                        }
                    );
            }

            return NoContent();

        }
        //Apis DELETE
        [HttpDelete]
        public IActionResult DeleteColaboradores(int id)
        {

            if (!_colaboradoresService.DeleteColaboradores(id))
            {
                return NotFound(
                        new
                        {
                            mensaje = "El colaborador no esta"
                        }
                    );
            }

            return NoContent();

        }


    }
}
