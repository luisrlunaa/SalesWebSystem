using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class NCFGenerados
    {
        [Key]
        public int id_secuencia { get; set; }
        public string secuenciaNCF { get; set; }
        public DateTime fecha { get; set; }

        public NCFGenerados()
        {
        }
    }
}
