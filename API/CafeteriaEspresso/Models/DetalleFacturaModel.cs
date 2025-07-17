namespace CafeteriaEspresso.Models
{
    public class DetalleFacturaModel
    {
        public int id { get; set; } // [pk, increment]
        public int cantidad { get; set; }
        public decimal subtotal { get; set; }
        public int id_factura { get; set; } // [fk, not null]
        public int id_producto { get; set; } // [fk, not null]
        
    }
}
