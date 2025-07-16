using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class DireccionService
    {

        private readonly AppDbContext _context;

        public DireccionService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<DireccionModel> _direccion = new List<DireccionModel>();
        private int _nextId = 1;


        //funcion de obtener direccions
        public List<DireccionModel> GetDireccionModel()
        { 
                return _context.G5_Direccion.ToList(); 
        }


        public DireccionModel GetById(int id) {
            return _context.G5_Direccion.FirstOrDefault(p=> p.id == id);
        }

        public DireccionModel AddG5_Direccion(DireccionModel DireccionModel)
        {
            _context.G5_Direccion.Add(DireccionModel);
            _context.SaveChanges();
            return DireccionModel;
        }


        public bool UpdateG5_Direccion(DireccionModel DireccionModel)
        {
            var entidad =  _context.G5_Direccion.FirstOrDefault(p => p.id == DireccionModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.detalle = DireccionModel.detalle;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Direccion(int id)
        {
            var entidad = _context.G5_Direccion.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Direccion.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
