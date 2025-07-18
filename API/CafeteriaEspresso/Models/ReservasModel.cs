namespace CafeteriaEspresso.Models
{
    public class ReservasModel
    {
        public int id { get; set; } // [pk, increment]
        public DateOnly fecha_reserva { get; set; }
        public int id_usuario { get; set; } // [ref: > Usuarios.id]
        public int id_estado { get; set; } // [ref: > Estado.id]
        public int id_metodo_pago { get; set; } // [ref: > Metodo_pago.id]
        public string nota_cliente { get; set; } // text
    }
}