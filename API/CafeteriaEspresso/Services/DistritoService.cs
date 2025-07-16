using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class DistritoService
    {

        private readonly AppDbContext _context;

        public DistritoService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<DistritoModel> _distrito = new List<DistritoModel>();
        private int _nextId = 1;


        //funcion de obtener distritos
        public List<DistritoModel> GetDistritoModel()
        { 
                return _context.G5_Distrito.ToList(); 
        }


        public DistritoModel GetById(int id) {
            return _context.G5_Distrito.FirstOrDefault(p=> p.id == id);
        }

        public DistritoModel AddG5_Distrito(DistritoModel DistritoModel)
        {
            _context.G5_Distrito.Add(DistritoModel);
            _context.SaveChanges();
            return DistritoModel;
        }


        public bool UpdateG5_Distrito(DistritoModel DistritoModel)
        {
            var entidad =  _context.G5_Distrito.FirstOrDefault(p => p.id == DistritoModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.nombre = DistritoModel.nombre;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Distrito(int id)
        {
            var entidad = _context.G5_Distrito.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Distrito.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
