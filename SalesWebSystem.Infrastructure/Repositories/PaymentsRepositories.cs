using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class PaymentsRepositories : DataTransactionManager, IPaymentsRepositories
    {
        public PaymentsRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Pagos>> PaymentsList() =>
            await _context.Pago.ToListAsync();

        public async Task<List<Pagos>> PaymentByBoxId(int idCaja) =>
            await _context.Pago.Where(x => x.id_caja == idCaja).ToListAsync();

        // Get
        public async Task<Pagos?> PaymentByPaymentId(int id) =>
            await _context.Pago.FirstOrDefaultAsync(x => x.id_pago == id);

        // Add
        public async Task<Pagos> AddPayment(Pagos Payment)
        {
            await _context.Pago.AddAsync(Payment);
            var committed = await CommitTransactionAsync();
            return committed ? Payment : null;
        }

        // Update
        public async Task<Pagos> UpdatePayment(Pagos Payment)
        {
            _context.Pago.Update(Payment);
            var committed = await CommitTransactionAsync();
            return committed ? Payment : null;
        }

        // Delete
        public async Task<Pagos?> DeletePaymentByPaymentId(int id)
        {
            var Payment = await PaymentByPaymentId(id);
            if (Payment is null)
                return null;

            _context.Pago.Remove(Payment);
            var committed = await CommitTransactionAsync();
            return committed ? Payment : null;
        }

        // Exists
        public async Task<bool> ExitPaymentByPaymentId(int id) =>
            await _context.Pago.AnyAsync(x => x.id_pago == id);
    }
}
