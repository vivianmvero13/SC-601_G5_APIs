using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class ReservasService
    {

        private readonly AppDbContext _context;

        public ReservasService(AppDbContext context)
        {
            _context = context;
        }

        //Aca necesitamos el modelo de datos para el almacenamiento temporal
        private readonly List<ReservasModel> _facturas = new List<ReservasModel>();
        private int _nextId = 1;


        //funcion de obtener reservas
        public List<ReservasModel> GetReservasModel()
        { 
                return _context.G5_Reservas.ToList(); 
        }


        public ReservasModel GetById(int id) {
            return _context.G5_Reservas.FirstOrDefault(p=> p.id == id);
        }

        public ReservasModel AddG5_Reservas(ReservasModel reservasModel)
        {
            _context.G5_Reservas.Add(reservasModel);
            _context.SaveChanges();
            return reservasModel;
        }


        public bool UpdateG5_Reservas(ReservasModel reservasModel) 
        {
            var entidad =  _context.G5_Reservas.FirstOrDefault(p => p.id == reservasModel.id);

            if (entidad == null) {
                return false;
            }

            entidad.fecha_reserva = reservasModel.fecha_reserva;
            entidad.id_usuario = reservasModel.id_usuario;
            entidad.id_estado = reservasModel.id_estado;
            entidad.id_metodo_pago = reservasModel.id_metodo_pago;
            entidad.nota_cliente = reservasModel.nota_cliente;



            _context.SaveChanges();

            return true;

        }


        public bool DeleteG5_Reservas(int id)
        {
            var entidad = _context.G5_Reservas.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Reservas.Remove(entidad);
            _context.SaveChanges();
            return true;

        }


    }
}
