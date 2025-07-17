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
        public DbSet<CantonModel> G5_Canton { get; set; }
        public DbSet<DistritoModel> G5_Distrito { get; set; }
        public DbSet<DireccionModel> G5_Direccion { get; set; }
        public DbSet<FacturasModel> G5_Facturas { get; set;}
        public DbSet<MetodoPagoModel> G5_Metodo_Pago { get; set; }
        public DbSet<ReservasModel> G5_Reservas { get; set; }
        public DbSet<PromocionesModel> G5_Promociones { get; set; }
        public DbSet<ResenasModel> G5_Resenias { get; set; }
        public DbSet<ProductosModel> G5_Productos { get; set; }
        public DbSet<CategoriaProductosModel> G5_Categoria_Productos { get; set; }
        public DbSet<InventarioModel> G5_Inventario { get; set; }
        public DbSet<ProveedoresModel> G5_Proveedores { get; set; }
        public DbSet<DetalleFacturaModel> G5_Detalle_Factura { get; set; }
    }
}
