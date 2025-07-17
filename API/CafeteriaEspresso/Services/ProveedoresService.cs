using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class ProveedoresService
    {

        private readonly AppDbContext _context;

        public ProveedoresService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<ProveedoresModel> _proveedores = new List<ProveedoresModel>();
        private int _nextId = 1;


        //funcion de obtener proveedoress
        public List<ProveedoresModel> GetProveedoresModel()
        {
            return _context.G5_Proveedores.ToList();
        }


        public ProveedoresModel GetById(int id)
        {
            return _context.G5_Proveedores.FirstOrDefault(p => p.id == id);
        }

        public ProveedoresModel AddG5_Proveedores(ProveedoresModel ProveedoresModel)
        {
            _context.G5_Proveedores.Add(ProveedoresModel);
            _context.SaveChanges();
            return ProveedoresModel;
        }


        public bool UpdateG5_Proveedores(ProveedoresModel ProveedoresModel)
        {
            var entidad = _context.G5_Proveedores.FirstOrDefault(p => p.id == ProveedoresModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.nombre = ProveedoresModel.nombre;
            entidad.telefono = ProveedoresModel.telefono;   
            entidad.correo = ProveedoresModel.correo;   
            entidad.direccion = ProveedoresModel.direccion; 


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Proveedores(int id)
        {
            var entidad = _context.G5_Proveedores.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Proveedores.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
