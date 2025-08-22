using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaEspresso.Services
{
    public class ProductosService
    {

        private readonly AppDbContext _context;

        public ProductosService(AppDbContext context)
        {
            _context = context;
        }

        private readonly List<ProductosModel> _productos = new List<ProductosModel>();
        private int _nextId = 1;


        public List<ProductosModel> GetProductosModel()
        {
            return _context.G5_Productos.ToList();
        }


        public ProductosModel GetById(int id)
        {
            return _context.G5_Productos.FirstOrDefault(p => p.id == id);
        }

        public ProductosModel AddG5_Productos(ProductosModel ProductosModel)
        {
            _context.G5_Productos.Add(ProductosModel);
            _context.SaveChanges();
            return ProductosModel;
        }


        public bool UpdateG5_Productos(ProductosModel ProductosModel)
        {
            var entidad = _context.G5_Productos.FirstOrDefault(p => p.id == ProductosModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.nombre = ProductosModel.nombre;
            entidad.descripcion = ProductosModel.descripcion;
            entidad.precio = ProductosModel.precio;
            entidad.id_categoria = ProductosModel.id_categoria;
            entidad.imagen = ProductosModel.imagen;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Productos(int id)
        {
            var entidad = _context.G5_Productos.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Productos.Remove(entidad);
            _context.SaveChanges();
            return true;

        }

        public List<ProductosModel> GetByCategoria(int id_cat)
        {
            return _context.G5_Productos.ToList();
        }

        public List<ProductosModel> Buscar(int? idCategoria, string? nombre)
        {
            var query = _context.G5_Productos.AsNoTracking().AsQueryable();

            if (idCategoria.HasValue)
                query = query.Where(p => p.id_categoria == idCategoria.Value);

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                nombre = nombre.Trim();
                query = query.Where(p => EF.Functions.Like(p.nombre, $"%{nombre}%"));
            }

            return query.ToList();
        }

    }
}
