namespace CafeteriaEspresso.Models
{
    public class InventarioModel
    {
        public int id { get; set; } // [pk, increment]
        public int cantidad { get; set; }
        public int id_producto { get; set; } // [not null, fk: G5_Productos.id]
        public int id_proveedor { get; set; } // [not null, fk: G5_Proveedores.id]
    }
}