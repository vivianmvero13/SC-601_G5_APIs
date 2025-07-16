using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class ProvinciaService
    {

        private readonly AppDbContext _context;

        public ProvinciaService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<ProvinciaModel> _provincia = new List<ProvinciaModel>();
        private int _nextId = 1;


        //funcion de obtener provincias
        public List<ProvinciaModel> GetProvinciaModel()
        { 
                return _context.G5_Provincia.ToList(); 
        }


        public ProvinciaModel GetById(int id) {
            return _context.G5_Provincia.FirstOrDefault(p=> p.id == id);
        }

        public ProvinciaModel AddG5_Provincia(ProvinciaModel ProvinciaModel)
        {
            _context.G5_Provincia.Add(ProvinciaModel);
            _context.SaveChanges();
            return ProvinciaModel;
        }


        public bool UpdateG5_Provincia(ProvinciaModel ProvinciaModel)
        {
            var entidad =  _context.G5_Provincia.FirstOrDefault(p => p.id == ProvinciaModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.nombre = ProvinciaModel.nombre;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Provincia(int id)
        {
            var entidad = _context.G5_Provincia.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Provincia.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
