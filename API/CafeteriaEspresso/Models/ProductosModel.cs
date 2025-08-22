namespace CafeteriaEspresso.Models
{
    public class ProductosModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; }
        public string descripcion { get; set; } 
        public decimal precio { get; set; }
        public int id_categoria { get; set; } // [fk, not null]
        public string imagen { get; set; }
    }
}