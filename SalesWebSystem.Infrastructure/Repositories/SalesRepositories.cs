using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class SalesRepositories : DataTransactionManager, ISalesRepositories
    {
        public SalesRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Venta>> SalesList() =>
            await _context.Ventas.ToListAsync();

        public async Task<List<DetalleVenta>> SalesDetailsList() =>
            await _context.DetalleVentas.ToListAsync();

        public async Task<List<Venta>> SaleByClientName(string clientName) =>
            await _context.Ventas.Where(x => x.NombreCliente == clientName).ToListAsync();

        public async Task<List<DetalleVenta>> SaleDetailsBySalesId(int id) =>
            await _context.DetalleVentas.Where(x => x.IdVenta == id).ToListAsync();

        // Get
        public async Task<Venta?> SaleBySaleId(int id) =>
            await _context.Ventas.FirstOrDefaultAsync(x => x.IdVenta == id);
        public async Task<DetalleVenta?> SaleDetailsBySaleIdAndDetailsId(int id, int detailId) =>
            await _context.DetalleVentas.FirstOrDefaultAsync(x => x.IdVenta == id && x.IdDetalleVenta == detailId);

        // Add
        public async Task<Venta> AddSale(Venta Sale)
        {
            await _context.Ventas.AddAsync(Sale);
            var committed = await CommitTransactionAsync();
            return committed ? Sale : null;
        }
        public async Task<DetalleVenta> AddSaleDetail(DetalleVenta detail)
        {
            await _context.DetalleVentas.AddAsync(detail);
            var committed = await CommitTransactionAsync();
            return committed ? detail : null;
        }

        // Update
        public async Task<Venta> UpdateSale(Venta Sale)
        {
            _context.Ventas.Update(Sale);
            var committed = await CommitTransactionAsync();
            return committed ? Sale : null;
        }
        public async Task<DetalleVenta> UpdateSaleDetail(DetalleVenta detail)
        {
            _context.DetalleVentas.Update(detail);
            var committed = await CommitTransactionAsync();
            return committed ? detail : null;
        }

        // Delete
        public async Task<Venta?> DeleteSaleBySaleId(int id)
        {
            var Sale = await SaleBySaleId(id);
            if (Sale is null)
                return null;

            _context.Ventas.Remove(Sale);
            var committed = await CommitTransactionAsync();
            return committed ? Sale : null;
        }
        public async Task<DetalleVenta?> DeleteSaleDetailBySaleIdAndDetailsId(int id, int detailId)
        {
            var Sale = await SaleDetailsBySaleIdAndDetailsId(id, detailId);
            if (Sale is null)
                return null;

            _context.DetalleVentas.Remove(Sale);
            var committed = await CommitTransactionAsync();
            return committed ? Sale : null;
        }

        // Exists
        public async Task<bool> ExitSaleBySaleId(int id) =>
            await _context.Ventas.AnyAsync(x => x.IdVenta == id);
        public async Task<bool> ExitDetailBySaleIdAndDetailsId(int id, int detailId) =>
            await _context.DetalleVentas.AnyAsync(x => x.IdVenta == id && x.IdDetalleVenta == detailId);
    }
}
