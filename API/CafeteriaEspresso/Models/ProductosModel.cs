namespace CafeteriaEspresso.Models
{
    public class ProductosModel
    {
        public int id { get; set; } // [pk, increment]
        public string nombre { get; set; }
        public string descripcion { get; set; } 
        public decimal precio { get; set; }
        public int id_categoria { get; set; } // [fk, not null]
    }
}

/*
 CREATE TABLE `u484426513_pac225`.G5_Productos (
  id int PRIMARY KEY AUTO_INCREMENT,
  nombre varchar(255),
  descripcion text,
  precio decimal,
  id_categoria int
);
 */