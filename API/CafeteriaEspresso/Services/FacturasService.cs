using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class FacturasService
    {

        private readonly AppDbContext _context;

        public FacturasService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<FacturasModel> _facturas = new List<FacturasModel>();
        private int _nextId = 1;


        //funcion de obtener resenas
        public List<FacturasModel> GetFacturasModel()
        {
            return _context.G5_Facturas.ToList();
        }


        public FacturasModel GetById(int id)
        {
            return _context.G5_Facturas.FirstOrDefault(p => p.id == id);
        }

        public FacturasModel AddG5_Facturas(FacturasModel facturasModel)
        {
            // Se autogenra_nextId
            //producto.Id = _nextId++;
            _context.G5_Facturas.Add(facturasModel);
            _context.SaveChanges();
            return facturasModel;
        }


        public bool UpdateG5_Facturas(FacturasModel facturasModel)
        {
            var entidad = _context.G5_Facturas.FirstOrDefault(p => p.id == facturasModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.fecha = facturasModel.fecha;
            entidad.total = facturasModel.total;
            entidad.nota_cliente = facturasModel.nota_cliente;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Facturas(int id)
        {
            var entidad = _context.G5_Facturas.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Facturas.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}

    
