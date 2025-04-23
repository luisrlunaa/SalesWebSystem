using System.ComponentModel.DataAnnotations;

namespace SalesWebSystem.Infrastructure.Data.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }

        public Categoria()
        {
        }
    }
}
