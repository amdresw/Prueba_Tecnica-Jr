using Microsoft.EntityFrameworkCore;

namespace FacturacionMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        //  Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //  tablas 
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Emisor> Emisores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
