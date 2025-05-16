using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class TypesRepositories : DataTransactionManager, ITypesRepositories
    {
        public TypesRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Tipo_factura>> InvoiceTypeList() =>
            await _context.Tipo_Facturas.ToListAsync();
        public async Task<List<Tipo_trabajo>> JobTypeList() =>
            await _context.Tipo_trabajo.ToListAsync();
        public async Task<List<tipoGOma>> CategoryTypeList() =>
            await _context.tipoGOma.ToListAsync();

        // Get
        public async Task<Tipo_factura?> InvoiceTypeById(int id) =>
            await _context.Tipo_Facturas.FirstOrDefaultAsync(x => x.id == id);
        public async Task<Tipo_trabajo?> JobTypeById(int id) =>
            await _context.Tipo_trabajo.FirstOrDefaultAsync(x => x.id == id);
        public async Task<tipoGOma?> CategoryTypeById(int id) =>
            await _context.tipoGOma.FirstOrDefaultAsync(x => x.id == id);

        // Add
        public async Task<Tipo_factura> AddInvoiceType(Tipo_factura type)
        {
            await _context.Tipo_Facturas.AddAsync(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<Tipo_trabajo> AddJobType(Tipo_trabajo type)
        {
            await _context.Tipo_trabajo.AddAsync(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<tipoGOma> AddCategoryType(tipoGOma type)
        {
            await _context.tipoGOma.AddAsync(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }

        // Update
        public async Task<Tipo_factura> UpdateInvoiceType(Tipo_factura type)
        {
            _context.Tipo_Facturas.Update(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<Tipo_trabajo> UpdateJobType(Tipo_trabajo type)
        {
            _context.Tipo_trabajo.Update(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<tipoGOma> UpdateCategoryType(tipoGOma type)
        {
            _context.tipoGOma.Update(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }

        // Delete
        public async Task<Tipo_factura?> DeleteInvoiceTypeBytypeId(int id)
        {
            var type = await InvoiceTypeById(id);
            if (type is null)
                return null;

            _context.Tipo_Facturas.Remove(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<Tipo_trabajo?> DeleteJobTypeBytypeId(int id)
        {
            var type = await JobTypeById(id);
            if (type is null)
                return null;

            _context.Tipo_trabajo.Remove(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }
        public async Task<tipoGOma?> DeleteCategoryTypeBytypeId(int id)
        {
            var type = await CategoryTypeById(id);
            if (type is null)
                return null;

            _context.tipoGOma.Remove(type);
            var committed = await CommitTransactionAsync();
            return committed ? type : null;
        }

        // Exists
        public async Task<bool> ExitInvoiceTypeBytypeId(int id) =>
            await _context.Tipo_Facturas.AnyAsync(x => x.id == id);
        public async Task<bool> ExitJobTypeBytypeId(int id) =>
            await _context.Tipo_trabajo.AnyAsync(x => x.id == id);
        public async Task<bool> ExitCategoryTypeBytypeId(int id) =>
            await _context.tipoGOma.AnyAsync(x => x.id == id);
    }
}
