namespace CafeteriaEspresso.Models
{
    public class ReservasModel
    {
        public int id { get; set; } // [pk, increment]
        public int id_usuario { get; set; } // [ref: > Usuarios.id]
        public string comentario { get; set; } // text
        public int calificacion { get; set; }
        public int id_producto { get; set; } // [ref: > Productos.id]
    }
}