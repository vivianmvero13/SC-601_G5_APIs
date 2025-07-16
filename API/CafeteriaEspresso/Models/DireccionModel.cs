namespace CafeteriaEspresso.Models
{
    public class DireccionModel
    {
        public int id { get; set; } // [pk, increment]
        public string detalle { get; set; }
        public int id_distrito{ get; set; } // [fk, not null]
        public int id_canton { get; set; } // [fk, not null]
        public int id_provincia { get; set; } // [fk, not null]
        public int id_pais { get; set; } // [fk, not null]
    }
}