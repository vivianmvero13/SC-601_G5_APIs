namespace CafeteriaEspresso.Models
{
    public class PromocionesModel
    {
        public int id { get; set; } // [pk, increment]
        public string descripcion { get; set; }
        public decimal descuento { get; set; }
        public DateOnly fecha_inicio { get; set; }
        public DateOnly fecha_fin { get; set; }
        public int id_producto { get; set; } // [ref: > Productos.id]
    }
}
    