using System.ComponentModel.DataAnnotations;

namespace CafeteriaEspresso.Models
{
    public class ClienteModel
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
       
    }
}
