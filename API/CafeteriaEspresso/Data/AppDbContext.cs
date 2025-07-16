using Microsoft.EntityFrameworkCore;
using CafeteriaEspresso.Models;

namespace CafeteriaEspresso.Data
{
    //creamos el contexto de la conexion de la db
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PaisModel> G5_Pais { get; set; }

        public DbSet<ProvinciaModel> G5_Provincia { get; set; }
        public DbSet<FacturasModel> G5_Facturas { get; set;}
        public DbSet<MetodoPagoModel> G5_Metodo_Pago { get; set; }
        public DbSet<ReservasModel> G5_Reservas { get; set; }
        public DbSet<PromocionesModel> G5_Promociones { get; set; }
        public DbSet<ResenasModel> G5_Resenias { get; set; }

    }
}
