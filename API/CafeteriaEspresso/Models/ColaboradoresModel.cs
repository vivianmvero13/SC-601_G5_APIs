using System.ComponentModel.DataAnnotations;

namespace CafeteriaEspresso.Models
{
    public class ColaboradoresModel
    {
        [Key]
        public int id { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public int id_usuario { get; set; }
    }
}
