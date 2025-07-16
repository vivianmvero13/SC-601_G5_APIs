namespace CafeteriaEspresso.Models
{
    public class ResenasModel
    {
        public int id { get; set; } // [pk, increment]
        public string comentario { get; set; } 
        public int calificacion { get; set; }
        public int id_usuario { get; set; } // [ref: > Usuarios.id]
        public int id_producto { get; set; } // [ref: > Productos.id]
    }
}
    