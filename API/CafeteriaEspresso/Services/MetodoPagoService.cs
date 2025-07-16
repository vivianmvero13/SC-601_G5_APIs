using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class MetodoPagoService
    {

        private readonly AppDbContext _context;

        public MetodoPagoService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<MetodoPagoModel> _metodoPago = new List<MetodoPagoModel>();
        private int _nextId = 1;


        //funcion de obtener metodos de pago
        public List<MetodoPagoModel> GetMetodoPagoModel()
        { 
                return _context.G5_Metodo_Pago.ToList(); 
        }


        public MetodoPagoModel GetById(int id) {
            return _context.G5_Metodo_Pago.FirstOrDefault(p=> p.id == id);
        }

        public MetodoPagoModel AddG5_Metodo_Pago(MetodoPagoModel metodoPagoModel)
        {
            _context.G5_Metodo_Pago.Add(metodoPagoModel);
            _context.SaveChanges();
            return metodoPagoModel;
        }


        public bool UpdateG5_Metodo_Pago(MetodoPagoModel metodoPagoModel)
        {
            var entidad =  _context.G5_Metodo_Pago.FirstOrDefault(p => p.id == metodoPagoModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.nombre = metodoPagoModel.nombre;


            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Metodo_Pago(int id)
        {
            var entidad = _context.G5_Metodo_Pago.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Metodo_Pago.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
