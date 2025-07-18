using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class RolesService
    {
        private readonly AppDbContext _context;

        public RolesService(AppDbContext context) 
        {
            _context = context;
        }
        private readonly List<RolesModel> _roles = new List<RolesModel>();
        private int _nextId = 1;


        //funcion de obtener 
        public List<RolesModel> GetRoles()
        {
            return _context.G5_Roles.ToList();
        }


        public RolesModel GetById(int id)
        {
            return _context.G5_Roles.FirstOrDefault(p => p.id == id);
        }

        public RolesModel AddRoles(RolesModel roles)
        {
            _context.G5_Roles.Add(roles);
            _context.SaveChanges();
            return roles;
        }


        public bool UpdateRoles(RolesModel roles)
        {
            var entidad = _context.G5_Roles.FirstOrDefault(p => p.id == roles.id);

            if (entidad == null)
            {
                return false;
            }
            
            entidad.id = roles.id;
            entidad.nombre= roles.nombre;
            

            _context.SaveChanges();

            return true;

        }


        public bool DeleteRoles(int id)
        {
            var entidad = _context.G5_Roles.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Roles.Remove(entidad);
            _context.SaveChanges();
            return true;

        }
    }
}
