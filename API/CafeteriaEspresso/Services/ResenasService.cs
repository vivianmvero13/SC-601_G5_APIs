using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class ResenasService
    {
        private readonly AppDbContext _context;

        public ResenasService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<ResenasModel> _resenas = new List<ResenasModel>();
        private int _nextId = 1;


        //funcion de obtener resenas
        public List<ResenasModel> GetResenasModel()
        {
            return _context.G5_Resenias.ToList();
        }


        public ResenasModel GetById(int id)
        {
            return _context.G5_Resenias.FirstOrDefault(p => p.id == id);
        }

        public ResenasModel AddG5_Resenias(ResenasModel resenasModel)
        {
            _context.G5_Resenias.Add(resenasModel);
            _context.SaveChanges();
            return resenasModel;
        }


        public bool UpdateG5_Resenias(ResenasModel resenasModel)
        {
            var entidad = _context.G5_Resenias.FirstOrDefault(p => p.id == resenasModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.comentario = resenasModel.comentario;
            entidad.calificacion = resenasModel.calificacion;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Resenias(int id)
        {
            var entidad = _context.G5_Resenias.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Resenias.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
