namespace CafeteriaEspresso.Models
{
    public class ProveedoresModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; } 
        public string telefono { get; set; } 
        public string correo { get; set; } 
        public int id_direccion { get; set; } 
          
    }
}
