using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class tipoGOma
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string descripcion { get; set; }

        public tipoGOma()
        {
        }
    }
}
