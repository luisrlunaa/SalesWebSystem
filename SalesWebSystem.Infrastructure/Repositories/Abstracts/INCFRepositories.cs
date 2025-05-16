using SalesWebSystem.Models.Models.DTO;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface INCFRepositories
    {
        Task<bool> NcfGenerator(int id_secuencia, string secuencia, int idNcf);

        Task<List<DropBoxDto>> ListNcfGenerate();
    }
}
