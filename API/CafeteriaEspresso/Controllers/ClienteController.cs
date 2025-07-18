using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        //Apis GET, POST, PUT y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> GetCliente()
        {
            return _clienteService.GetCliente();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteModel> GetById(int id)
        {
            return _clienteService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<ClienteModel> AddCliente(ClienteModel cliente)
        {
            var newCliente = _clienteService.AddCliente(cliente);

            return CreatedAtAction(
                nameof(GetCliente), new
                {
                    id = newCliente.id,
                },
                newCliente);
        }

        //Apis PUT
        [HttpPut]
        public IActionResult UpdateCliente(ClienteModel cliente)
        {
            if (!_clienteService.UpdateCliente(cliente))
            {
                return NotFound(new
                {
                    mensaje = "El Cliente no está"
                });
            }

            return NoContent();
        }

        //Apis DELETE
        [HttpDelete]
        public IActionResult DeleteCliente(int id)
        {
            if (!_clienteService.DeleteCliente(id))
            {
                return NotFound(new
                {
                    mensaje = "El cliente no está"
                });
            }

            return NoContent();
        }

    }
}
