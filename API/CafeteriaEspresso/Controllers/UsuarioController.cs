using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        //Apis GET, POST, PUT   y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioModel>> GetUsuario()
        {
            return _usuarioService.GetUsuario();
            
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioModel> GetById(int id)
        {
            return _usuarioService.GetById(id);
        }
        //Apis POST
        [HttpPost]
        public ActionResult<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {

            var newUsuario = _usuarioService.AddUsuario(usuario);

            return
                CreatedAtAction(
                        nameof(GetUsuario), new
                        {
                            id = newUsuario.id,
                        },
                        newUsuario);

        }
        //Apis PUT
        [HttpPut]
        public IActionResult UpdateUsuario(UsuarioModel usuario)
        {

            if (!_usuarioService.UpdateUsuario(usuario))
            {
                return NotFound(
                        new
                        {
                            mensaje = "El Usuario no esta"
                        }
                    );
            }

            return NoContent();

        }
        //Apis DELETE
        [HttpDelete]
        public IActionResult DeleteUsuario(int id)
        {

            if (!_usuarioService.DeleteUsuario(id))
            {
                return NotFound(
                        new
                        {
                            mensaje = "El usuario no esta"
                        }
                    );
            }

            return NoContent();

        }


    }
}
