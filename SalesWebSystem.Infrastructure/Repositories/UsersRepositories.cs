using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class UsersRepositories : DataTransactionManager, IUsersRepositories
    {
        public UsersRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Usuarios>> UsersList() =>
            await _context.UserTable.ToListAsync();

        // Get
        public async Task<Usuarios?> UserByUserId(int id) =>
            await _context.UserTable.FirstOrDefaultAsync(x => x.IdUsuario == id);

        public async Task<Usuarios?> UserByUserName(string userName) =>
            await _context.UserTable.FirstOrDefaultAsync(x => x.Usuario == userName);

        // Add
        public async Task<Usuarios> AddUser(Usuarios User)
        {
            await _context.UserTable.AddAsync(User);
            var committed = await CommitTransactionAsync();
            return committed ? User : null;
        }

        // Update
        public async Task<Usuarios> UpdateUser(Usuarios User)
        {
            _context.UserTable.Update(User);
            var committed = await CommitTransactionAsync();
            return committed ? User : null;
        }

        // Delete
        public async Task<Usuarios?> DeleteUserByUserId(int id)
        {
            var User = await UserByUserId(id);
            if (User is null)
                return null;

            _context.UserTable.Remove(User);
            var committed = await CommitTransactionAsync();
            return committed ? User : null;
        }

        // Exists
        public async Task<bool> ExitUserByUserId(int id) =>
            await _context.UserTable.AnyAsync(x => x.IdUsuario == id);

        public async Task<bool> ExitUserByUserName(string userName) =>
            await _context.UserTable.AnyAsync(x => x.Usuario == userName);
    }
}
