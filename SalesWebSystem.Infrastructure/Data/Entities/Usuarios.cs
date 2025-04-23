using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        [NotMapped]
        public int IdCliente { get; set; }
        [Required]
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        [NotMapped]
        [Compare("Contraseña")]
        public string ConfirmPassword { get; set; }
        public Usuarios()
        {
        }
    }
}
