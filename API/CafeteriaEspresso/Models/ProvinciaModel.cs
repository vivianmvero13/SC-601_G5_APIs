namespace CafeteriaEspresso.Models
{
    public class ProvinciaModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; }

        public int id_pais { get; set; } // [fk, not null]
    }
}
    