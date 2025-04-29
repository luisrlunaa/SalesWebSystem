using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class ClientsRepositories : DataTransactionManager, IClientsRepositories
    {
        public ClientsRepositories(InvSysContext context) : base(context) { }

        // List
        public async Task<List<Cliente>> ClientsList() =>
            await _context.Clientes.ToListAsync();

        // Get
        public async Task<Cliente?> ClientByClientId(int id) =>
            await _context.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

        public async Task<Cliente?> ClientByClientName(string clientName) =>
            await _context.Clientes.FirstOrDefaultAsync(x => x.Nombres == clientName);

        public async Task<Cliente?> ClientByClientPhone(string clientPhone) =>
            await _context.Clientes.FirstOrDefaultAsync(x => x.Telefono == clientPhone);

        // Add
        public async Task<Cliente> AddClient(Cliente Client)
        {
            await _context.Clientes.AddAsync(Client);
            var committed = await CommitTransactionAsync();
            return committed ? Client : null;
        }

        // Update
        public async Task<Cliente> UpdateClient(Cliente Client)
        {
            _context.Clientes.Update(Client);
            var committed = await CommitTransactionAsync();
            return committed ? Client : null;
        }

        // Delete
        public async Task<Cliente?> DeleteClientByClientId(int id)
        {
            var Client = await ClientByClientId(id);
            if (Client is null)
                return null;

            _context.Clientes.Remove(Client);
            var committed = await CommitTransactionAsync();
            return committed ? Client : null;
        }

        // Exists
        public async Task<bool> ExitClientByClientId(int id) =>
            await _context.Clientes.AnyAsync(x => x.IdCliente == id);

        public async Task<bool> ExitClientByClientName(string clientName) =>
            await _context.Clientes.AnyAsync(x => x.Nombres == clientName);

        public async Task<bool> ExitClientByClientPhone(string clientPhone) =>
            await _context.Clientes.AnyAsync(x => x.Telefono == clientPhone);
    }
}
