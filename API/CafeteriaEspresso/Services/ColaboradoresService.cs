using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class ColaboradoresService
    {
        private readonly AppDbContext _context;

        public ColaboradoresService(AppDbContext context) 
        {
            _context = context;
        }
        private readonly List<ColaboradoresModel> _colaboradores = new List<ColaboradoresModel>();
        private int _nextId = 1;


        //funcion de obtener 
        public List<ColaboradoresModel> GetColaboradores()
        {
            return _context.G5_Colaboradores.ToList();
        }


        public ColaboradoresModel GetById(int id)
        {
            return _context.G5_Colaboradores.FirstOrDefault(p => p.id == id);
        }

        public ColaboradoresModel AddColaboradores(ColaboradoresModel colaboradores)
        {
            _context.G5_Colaboradores.Add(colaboradores);
            _context.SaveChanges();
            return colaboradores;
        }


        public bool UpdateColaboradores(ColaboradoresModel colaboradores)
        {
            var entidad = _context.G5_Colaboradores.FirstOrDefault(p => p.id == colaboradores.id);

            if (entidad == null)
            {
                return false;
            }
       
            entidad.id = colaboradores.id;
            entidad.fecha_ingreso = colaboradores.fecha_ingreso;
            entidad.id_usuario = colaboradores.id_usuario;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteColaboradores(int id)
        {
            var entidad = _context.G5_Colaboradores.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Colaboradores.Remove(entidad);
            _context.SaveChanges();
            return true;

        }
    }
}
