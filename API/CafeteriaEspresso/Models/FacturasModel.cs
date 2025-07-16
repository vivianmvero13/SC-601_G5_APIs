namespace CafeteriaEspresso.Models
{
    public class FacturasModel
    {
        public int id { get; set; }
        public DateOnly fecha { get; set; }
        public decimal total { get; set; }
        public int id_Usuario { get; set; }
        public int id_metodo_pago { get; set; }
        public string nota_cliente { get; set; }
    }
}
    