using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }
        public string Descripcion { get; set; }

        public Cargo()
        {
        }
    }
}
