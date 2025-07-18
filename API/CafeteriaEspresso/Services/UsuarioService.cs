using CafeteriaEspresso.Data;
using CafeteriaEspresso.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaEspresso.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context) 
        {
            _context = context;
        }
        private readonly List<UsuarioModel> _usuario = new List<UsuarioModel>();
        private int _nextId = 1;


        //funcion de obtener 
        public List<UsuarioModel> GetUsuario()
        {
            return _context.G5_Usuarios.ToList();
        }


        public UsuarioModel GetById(int id)
        {
            return _context.G5_Usuarios.FirstOrDefault(p => p.id == id);
        }

        public UsuarioModel AddUsuario(UsuarioModel usuario)
        {
            _context.G5_Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }


        public bool UpdateUsuario(UsuarioModel usuario)
        {
            var entidad = _context.G5_Usuarios.FirstOrDefault(p => p.id == usuario.id);

            if (entidad == null)
            {
                return false;
            }

            entidad.id = usuario.id;
            entidad.nombre = usuario.nombre;
            entidad.correo = usuario.correo;
            entidad.contrasena = usuario.contrasena;
            entidad.id_rol = usuario.id_rol;
            entidad.id_direccion = usuario.id_direccion;
            entidad.telefono = usuario.telefono;
            entidad.fecha_registro = usuario.fecha_registro;
            entidad.id_estado = usuario.id_estado;

            _context.SaveChanges();

            return true;

        }


        public bool DeleteUsuario(int id)
        {
            var entidad = _context.G5_Usuarios.FirstOrDefault(p => p.id == id);

            if (entidad == null)
            {
                return false;
            }

            _context.G5_Usuarios.Remove(entidad);
            _context.SaveChanges();
            return true;

        }
    }
}
