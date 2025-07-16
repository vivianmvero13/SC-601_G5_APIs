using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class PaisService
    {

        private readonly AppDbContext _context;

        public PaisService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<PaisModel> _pais = new List<PaisModel>();
        private int _nextId = 1;


        //funcion de obtener paises
        public List<PaisModel> GetPaisModel()
        { 
                return _context.G5_Pais.ToList(); 
        }


        public PaisModel GetById(int id) {
            return _context.G5_Pais.FirstOrDefault(p=> p.id == id);
        }

        public PaisModel AddG5_Pais(PaisModel PaisModel)
        {
            _context.G5_Pais.Add(PaisModel);
            _context.SaveChanges();
            return PaisModel;
        }


        public bool UpdateG5_Pais(PaisModel PaisModel)
        {
            var entidad =  _context.G5_Pais.FirstOrDefault(p => p.id == PaisModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.nombre = PaisModel.nombre;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Pais(int id)
        {
            var entidad = _context.G5_Pais.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Pais.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
