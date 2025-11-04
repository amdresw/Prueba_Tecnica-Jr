using System.ComponentModel.DataAnnotations;

namespace FacturacionMVC.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        [RegularExpression("^[0-9]{6,10}(-[0-9])?$", ErrorMessage = "La identificación no es válida.")]
        public string Identificacion { get; set; }

        [Required, StringLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$", ErrorMessage = "El nombre solo puede contener letras.")]
        public string Nombres { get; set; }

        [Required, StringLength(50)]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúñÑ\\s]+$", ErrorMessage = "El apellido solo puede contener letras.")]
        public string Apellidos { get; set; }

        [Required, StringLength(20)]
        [RegularExpression("^[0-9]{7,15}$", ErrorMessage = "El teléfono no es válido.")]
        public string Telefono { get; set; }

        [Required, EmailAddress, StringLength(100)]
        [RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$", 
        ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required, StringLength(100)]
        public string Direccion { get; set; }
    }
}
