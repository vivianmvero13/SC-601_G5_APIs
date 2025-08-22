using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaEspresso.Services
{
    public class FacturasService
    {

        private readonly AppDbContext _context;

        public FacturasService(AppDbContext context)
        {
            _context = context;
        }

        private readonly List<FacturasModel> _facturas = new List<FacturasModel>();
        private int _nextId = 1;


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

        public List<FacturasModel> GetHistorialPorUsuario(int id_Usuario)
        {
            return _context.G5_Facturas
                           .Where(f => f.id_Usuario == id_Usuario) 
                           .OrderByDescending(f => f.fecha)
                           .ToList();
        }

        public List<FacturasModel> BuscarFacturas(int? idUsuario, int? idFactura, DateOnly? desde, DateOnly? hasta)
        {
            var q = _context.G5_Facturas.AsQueryable();

            if (idUsuario.HasValue)
                q = q.Where(f => f.id_Usuario == idUsuario.Value);

            if (idFactura.HasValue)
                q = q.Where(f => f.id == idFactura.Value);

            if (desde.HasValue)
            {
                q = q.Where(f => f.fecha >= desde);
            }

            if (hasta.HasValue)
            {
                
                q = q.Where(f => f.fecha < hasta);
            }

            return q.OrderByDescending(f => f.fecha).ToList();
        }

    }
}

    
