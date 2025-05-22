using System.ComponentModel.DataAnnotations;

namespace ROPA.Frontend.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "Precio inválido")]
        public decimal Precio { get; set; }

        [Range(0, 10000, ErrorMessage = "Stock inválido")]
        public int Stock { get; set; }
    }
}
