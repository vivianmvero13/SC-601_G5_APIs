using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class CategoriaProductosService
    {

        private readonly AppDbContext _context;

        public CategoriaProductosService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<CategoriaProductosModel> _categoriaProductos = new List<CategoriaProductosModel>();
        private int _nextId = 1;


        //funcion de obtener CategoriaProductos
        public List<CategoriaProductosModel> GetCategoriaProductosModel()
        {
            return _context.G5_Categoria_Productos.ToList();
        }


        public CategoriaProductosModel GetById(int id)
        {
            return _context.G5_Categoria_Productos.FirstOrDefault(p => p.id == id);
        }

        public CategoriaProductosModel AddG5_Categoria_Productos(CategoriaProductosModel CategoriaProductosModel)
        {
            _context.G5_Categoria_Productos.Add(CategoriaProductosModel);
            _context.SaveChanges();
            return CategoriaProductosModel;
        }


        public bool UpdateG5_Categoria_Productos(CategoriaProductosModel CategoriaProductosModel)
        {
            var entidad = _context.G5_Categoria_Productos.FirstOrDefault(p => p.id == CategoriaProductosModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.nombre = CategoriaProductosModel.nombre;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Categoria_Productos(int id)
        {
            var entidad = _context.G5_Categoria_Productos.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Categoria_Productos.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
