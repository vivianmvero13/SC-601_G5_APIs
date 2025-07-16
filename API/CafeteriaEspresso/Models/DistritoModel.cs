namespace CafeteriaEspresso.Models
{
    public class DistritoModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; }
        public int id_canton { get; set; } // [fk, not null]
    }
}