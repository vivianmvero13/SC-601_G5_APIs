namespace CafeteriaEspresso.Models
{
    public class CantonModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; }
        public int id_provincia { get; set; } // [fk, not null]
    }
}