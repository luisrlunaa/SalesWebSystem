using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IUsersRepositories
    {
        // List
        Task<List<Usuarios>> UsersList();

        // Get
        Task<Usuarios?> UserByUserId(int id);

        Task<Usuarios?> UserByUserName(string userName);

        // Add
        Task<Usuarios> AddUser(Usuarios User);
        // Update
        Task<Usuarios> UpdateUser(Usuarios User);

        // Delete
        Task<Usuarios?> DeleteUserByUserId(int id);

        // Exists
        Task<bool> ExitUserByUserId(int id);

        Task<bool> ExitUserByUserName(string userName);
    }
}
