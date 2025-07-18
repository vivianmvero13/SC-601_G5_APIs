using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class EstadosService
    {
        private readonly AppDbContext _context;

        public EstadosService(AppDbContext context) 
        {
            _context = context;
        }
        private readonly List<EstadosModel> _estados = new List<EstadosModel>();
        private int _nextId = 1;


        //funcion de obtener 
        public List<EstadosModel> GetEstados()
        {
            return _context.G5_Estados.ToList();
        }


        public EstadosModel GetById(int id)
        {
            return _context.G5_Estados.FirstOrDefault(p => p.id == id);
        }

        public EstadosModel AddEstados(EstadosModel estados)
        {
            _context.G5_Estados.Add(estados);
            _context.SaveChanges();
            return estados;
        }


        public bool UpdateEstados(EstadosModel estados)
        {
            var entidad = _context.G5_Estados.FirstOrDefault(p => p.id == estados.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.id = estados.id;
            entidad.nombre= estados.nombre;
            

            _context.SaveChanges();

            return true;

        }


        public bool DeleteEstados(int id)
        {
            var entidad = _context.G5_Estados.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Estados.Remove(entidad);
            _context.SaveChanges();
            return true;

        }
    }
}
