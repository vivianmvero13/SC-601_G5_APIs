using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class DetalleFacturaService
    {

        private readonly AppDbContext _context;

        public DetalleFacturaService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<DetalleFacturaModel> _detalleFactura = new List<DetalleFacturaModel>();
        private int _nextId = 1;


        //funcion de obtener DetalleFactura
        public List<DetalleFacturaModel> GetDetalleFacturaModel()
        {
            return _context.G5_Detalle_Factura.ToList();
        }


        public DetalleFacturaModel GetById(int id)
        {
            return _context.G5_Detalle_Factura.FirstOrDefault(p => p.id == id);
        }

        public DetalleFacturaModel AddG5_Detalle_Factura(DetalleFacturaModel DetalleFacturaModel)
        {
            _context.G5_Detalle_Factura.Add(DetalleFacturaModel);
            _context.SaveChanges();
            return DetalleFacturaModel;
        }


        public bool UpdateG5_Detalle_Factura(DetalleFacturaModel DetalleFacturaModel)
        {
            var entidad = _context.G5_Detalle_Factura.FirstOrDefault(p => p.id == DetalleFacturaModel.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.cantidad = DetalleFacturaModel.cantidad;
            entidad.subtotal = DetalleFacturaModel.subtotal;
            entidad.id_factura = DetalleFacturaModel.id_factura;
            entidad.id_producto = DetalleFacturaModel.id_producto;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Detalle_Factura(int id)
        {
            var entidad = _context.G5_Detalle_Factura.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Detalle_Factura.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
