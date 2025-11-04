using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturacionMVC.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }

        [Required]
        public int IdFactura { get; set; }

        [Required]
        public int IdProducto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "numeric(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "numeric(12,2)")]
        public decimal Subtotal { get; set; }

        [ValidateNever]
        [ForeignKey("IdFactura")]
        public Factura Factura { get; set; }

        [ValidateNever]
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
