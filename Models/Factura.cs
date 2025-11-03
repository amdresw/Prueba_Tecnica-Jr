using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionMVC.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdEmisor { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "numeric(12,2)")]
        public decimal? TotalFactura { get; set; }

        // Relaciones
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdEmisor")]
        public Emisor Emisor { get; set; }

        public ICollection<DetalleFactura> Detalles { get; set; }
    }
}
