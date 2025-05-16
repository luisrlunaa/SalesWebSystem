using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IPaymentsRepositories
    {
        // List
        Task<List<Pagos>> PaymentsList();
        Task<List<Pagos>> PaymentByBoxId(int idCaja);

        // Get
        Task<Pagos?> PaymentByPaymentId(int id);

        // Add
        Task<Pagos> AddPayment(Pagos Payment);

        // Update
        Task<Pagos> UpdatePayment(Pagos Payment);

        // Delete
        Task<Pagos?> DeletePaymentByPaymentId(int id);

        // Exists
        Task<bool> ExitPaymentByPaymentId(int id);
    }
}
