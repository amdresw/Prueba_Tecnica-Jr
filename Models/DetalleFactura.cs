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

        [Required, Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        [Column(TypeName = "numeric(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "numeric(12,2)")]
        public decimal Subtotal => Cantidad * PrecioUnitario;

        // Relaciones
        [ForeignKey("IdFactura")]
        public Factura Factura { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
