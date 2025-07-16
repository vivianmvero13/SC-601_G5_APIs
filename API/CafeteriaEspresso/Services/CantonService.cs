using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class CantonService
    {

        private readonly AppDbContext _context;

        public CantonService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<CantonModel> _canton = new List<CantonModel>();
        private int _nextId = 1;


        //funcion de obtener cantons
        public List<CantonModel> GetCantonModel()
        { 
                return _context.G5_Canton.ToList(); 
        }


        public CantonModel GetById(int id) {
            return _context.G5_Canton.FirstOrDefault(p=> p.id == id);
        }

        public CantonModel AddG5_Canton(CantonModel CantonModel)
        {
            _context.G5_Canton.Add(CantonModel);
            _context.SaveChanges();
            return CantonModel;
        }


        public bool UpdateG5_Canton(CantonModel CantonModel)
        {
            var entidad =  _context.G5_Canton.FirstOrDefault(p => p.id == CantonModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.nombre = CantonModel.nombre;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Canton(int id)
        {
            var entidad = _context.G5_Canton.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Canton.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
