using System.ComponentModel.DataAnnotations;

namespace CafeteriaEspresso.Models
{
    public class EstadosModel
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
       
    }
}
