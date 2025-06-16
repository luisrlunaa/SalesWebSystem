using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class BusinessRepositories : DataTransactionManager, IBusinessRepositories
    {
        public BusinessRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Caja>> BoxesList() =>
            await _context.Cajas.ToListAsync();
        public async Task<List<Cuadre>> CashBalanceList() =>
            await _context.Cuadre.ToListAsync();
        public async Task<List<Licencia>> LicensesList() =>
            await _context.Licencia.ToListAsync();
        public async Task<List<NomEmp>> BusinessInfoList() =>
            await _context.NomEmps.ToListAsync();

        // Get
        public async Task<Caja?> LastBox() =>
            await _context.Cajas.LastOrDefaultAsync();
        public async Task<Caja?> BoxById(int id) =>
            await _context.Cajas.FirstOrDefaultAsync(x => x.id_caja == id);
        public async Task<Cuadre?> CashBalanceById(int id) =>
            await _context.Cuadre.FirstOrDefaultAsync(x => x.id == id);
        public async Task<Licencia?> LicenseById(int id) =>
            await _context.Licencia.FirstOrDefaultAsync(x => x.id == id);
        public async Task<NomEmp?> BusinessInfoById(int id) =>
            await _context.NomEmps.FirstOrDefaultAsync(x => x.idEmp == id);


        // Add
        public async Task<Caja> AddBox(Caja input)
        {
            await _context.Cajas.AddAsync(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Cuadre> AddCashBalance(Cuadre input)
        {
            await _context.Cuadre.AddAsync(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Licencia> AddLicense(Licencia input)
        {
            await _context.Licencia.AddAsync(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<NomEmp> AddBusinessInfo(NomEmp input)
        {
            await _context.NomEmps.AddAsync(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }

        // Update
        public async Task<Caja> UpdateBox(Caja input)
        {
            _context.Cajas.Update(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Cuadre> UpdateCashBalance(Cuadre input)
        {
            _context.Cuadre.Update(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Licencia> UpdateLicense(Licencia input)
        {
            _context.Licencia.Update(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<NomEmp> UpdateBusinessInfo(NomEmp input)
        {
            _context.NomEmps.Update(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }

        // Delete
        public async Task<Caja?> DeleteBoxById(int id)
        {
            var input = await BoxById(id);
            if (input is null)
                return null;

            _context.Cajas.Remove(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Cuadre?> DeleteCashBalanceById(int id)
        {
            var input = await CashBalanceById(id);
            if (input is null)
                return null;

            _context.Cuadre.Remove(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<Licencia?> DeleteLicenseById(int id)
        {
            var input = await LicenseById(id);
            if (input is null)
                return null;

            _context.Licencia.Remove(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }
        public async Task<NomEmp?> DeleteBusinessInfoById(int id)
        {
            var input = await BusinessInfoById(id);
            if (input is null)
                return null;

            _context.NomEmps.Remove(input);
            var committed = await CommitTransactionAsync();
            return committed ? input : null;
        }

        // Exists
        public async Task<bool> ExitBoxById(int id) =>
            await _context.Cajas.AnyAsync(x => x.id_caja == id);
        public async Task<bool> ExitCashBalanceById(int id) =>
            await _context.Cuadre.AnyAsync(x => x.id == id);
        public async Task<bool> ExitLicenseById(int id) =>
            await _context.Licencia.AnyAsync(x => x.id == id);
        public async Task<bool> ExitBusinessInfoById(int id) =>
            await _context.NomEmps.AnyAsync(x => x.idEmp == id);
    }
}