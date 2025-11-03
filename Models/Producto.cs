using System.ComponentModel.DataAnnotations;

namespace FacturacionMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        [RegularExpression("^[A-Za-z0-9_-]+$", ErrorMessage = "El código solo puede contener letras, números, guiones y guiones bajos.")]
        public string Codigo { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }
    }
}
