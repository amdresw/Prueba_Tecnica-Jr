using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FacturacionMVC.Models
{
    public class Factura
    {
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdEmisor { get; set; }

        [Column(TypeName = "timestamp without time zone")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "numeric(12,2)")]
        public decimal? TotalFactura { get; set; }

        // Relaciones
        [ForeignKey("IdCliente")]
        [ValidateNever] // ✅ agregado aquí
        public Cliente Cliente { get; set; }

        [ForeignKey("IdEmisor")]
        [ValidateNever] // ✅ agregado aquí
        public Emisor Emisor { get; set; }

        [ValidateNever] // ✅ agregado aquí
        public ICollection<DetalleFactura> Detalles { get; set; }
    }
}
