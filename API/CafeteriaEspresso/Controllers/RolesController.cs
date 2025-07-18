using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using CafeteriaEspresso.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : Controller
    {
        private readonly RolesService _rolesService;

        public RolesController(RolesService rolesService)
        {
            _rolesService = rolesService;
        }

        //Apis GET, POST, PUT y DELETE

        //Apis GET
        [HttpGet]
        public ActionResult<IEnumerable<RolesModel>> GetRoles()
        {
            return _rolesService.GetRoles();
        }

        [HttpGet("{id}")]
        public ActionResult<RolesModel> GetById(int id)
        {
            return _rolesService.GetById(id);
        }

        //Apis POST
        [HttpPost]
        public ActionResult<RolesModel> AddRoles(RolesModel roles)
        {
            var newRoles = _rolesService.AddRoles(roles);

            return CreatedAtAction(
                nameof(GetRoles), new
                {
                    id = newRoles.id,
                },
                newRoles);
        }

        //Apis PUT
        [HttpPut]
        public IActionResult UpdateRoles(RolesModel roles)
        {
            if (!_rolesService.UpdateRoles(roles))
            {
                return NotFound(new
                {
                    mensaje = "El rol no está"
                });
            }

            return NoContent();
        }

        //Apis DELETE
        [HttpDelete]
        public IActionResult DeleteRoles(int id)
        {
            if (!_rolesService.DeleteRoles (id))
            {
                return NotFound(new
                {
                    mensaje = "El rol no está"
                });
            }

            return NoContent();
        }

    }
}
