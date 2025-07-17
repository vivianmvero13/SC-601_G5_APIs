using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class InventarioService
    {

        private readonly AppDbContext _context;

        public InventarioService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<InventarioModel> _inventario = new List<InventarioModel>();
        private int _nextId = 1;


        //funcion de obtener inventarios
        public List<InventarioModel> GetInventarioModel()
        {
            return _context.G5_Inventario.ToList();
        }


        public InventarioModel GetById(int id)
        {
            return _context.G5_Inventario.FirstOrDefault(p => p.id == id);
        }

        public InventarioModel AddG5_Inventario(InventarioModel InventarioModel)
        {
            _context.G5_Inventario.Add(InventarioModel);
            _context.SaveChanges();
            return InventarioModel;
        }


        public bool UpdateG5_Inventario(InventarioModel InventarioModel)
        {
            var entidad = _context.G5_Inventario.FirstOrDefault(p => p.id == InventarioModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.cantidad = InventarioModel.cantidad;
            entidad.id_producto = InventarioModel.id_producto;
            entidad.id_proveedor = InventarioModel.id_proveedor;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Inventario(int id)
        {
            var entidad = _context.G5_Inventario.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Inventario.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}