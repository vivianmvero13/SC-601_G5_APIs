using System.ComponentModel.DataAnnotations;

namespace CafeteriaEspresso.Models

{
    public class UsuarioModel
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int id_rol { get; set; }
        public int id_direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fecha_registro { get; set; }
        public int id_estado { get; set; }
    }
}
