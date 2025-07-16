using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class PromocionesService
    {

        private readonly AppDbContext _context;

        public PromocionesService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<PromocionesModel> _facturas = new List<PromocionesModel>();
        private int _nextId = 1;


        //funcion de obtener Promociones
        public List<PromocionesModel> GetPromocionesModel()
        { 
                return _context.G5_Promociones.ToList(); 
        }


        public PromocionesModel GetById(int id) {
            return _context.G5_Promociones.FirstOrDefault(p=> p.id == id);
        }

        public PromocionesModel AddG5_Promociones(PromocionesModel promocionesModel)
        {
            _context.G5_Promociones.Add(promocionesModel);
            _context.SaveChanges();
            return promocionesModel;
        }


        public bool UpdateG5_Promociones(PromocionesModel promocionesModel)
        {
            var entidad =  _context.G5_Promociones.FirstOrDefault(p => p.id == promocionesModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.descripcion = promocionesModel.descripcion;
            entidad.descuento = promocionesModel.descuento;
            entidad.fecha_inicio = promocionesModel.fecha_inicio;
            entidad.fecha_fin = promocionesModel.fecha_fin;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Promociones(int id)
        {
            var entidad = _context.G5_Promociones.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Promociones.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
