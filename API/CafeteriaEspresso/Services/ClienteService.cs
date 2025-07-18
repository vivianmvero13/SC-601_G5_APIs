using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services

{
    public class ClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context) 
        {
            _context = context;
        }
        private readonly List<ClienteModel> _cliente = new List<ClienteModel>();
        private int _nextId = 1;


        //funcion de obtener 
        public List<ClienteModel> GetCliente()
        {
            return _context.G5_Clientes.ToList();
        }


        public ClienteModel GetById(int id)
        {
            return _context.G5_Clientes.FirstOrDefault(p => p.id == id);
        }

        public ClienteModel AddCliente(ClienteModel cliente)
        {
            _context.G5_Clientes.Add(cliente);
            _context.SaveChanges();
            return cliente;
        }


        public bool UpdateCliente(ClienteModel cliente)
        {
            var entidad = _context.G5_Clientes.FirstOrDefault(p => p.id == cliente.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.id = cliente.id;
            entidad.id_usuario= cliente.id_usuario;
            

            _context.SaveChanges();

            return true;

        }


        public bool DeleteCliente(int id)
        {
            var entidad = _context.G5_Clientes.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Clientes.Remove(entidad);
            _context.SaveChanges();
            return true;

        }
    }
}
