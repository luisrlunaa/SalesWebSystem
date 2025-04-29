using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IClientsRepositories
    {
        // List
        Task<List<Cliente>> ClientsList();

        // Get
        Task<Cliente?> ClientByClientId(int id);
        Task<Cliente?> ClientByClientName(string clientName);
        Task<Cliente?> ClientByClientPhone(string clientPhone);

        // Add
        Task<Cliente> AddClient(Cliente Client);

        // Update
        Task<Cliente> UpdateClient(Cliente Client);

        // Delete
        Task<Cliente?> DeleteClientByClientId(int id);

        // Exists
        Task<bool> ExitClientByClientId(int id);
        Task<bool> ExitClientByClientName(string clientName);
        Task<bool> ExitClientByClientPhone(string clientPhone);
    }
}
