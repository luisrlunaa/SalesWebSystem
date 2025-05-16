using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface ISalesRepositories
    {

        // List
        Task<List<Venta>> SalesList();
        Task<List<DetalleVenta>> SalesDetailsList();

        Task<List<Venta>> SaleByClientName(string clientName);
        Task<List<DetalleVenta>> SaleDetailsBySalesId(int id);

        // Get
        Task<Venta?> SaleBySaleId(int id);
        Task<DetalleVenta?> SaleDetailsBySaleIdAndDetailsId(int id, int detailId);

        // Add
        Task<Venta> AddSale(Venta Sale);
        Task<DetalleVenta> AddSaleDetail(DetalleVenta detail);

        // Update
        Task<Venta> UpdateSale(Venta Sale);
        Task<DetalleVenta> UpdateSaleDetail(DetalleVenta detail);

        // Delete
        Task<Venta?> DeleteSaleBySaleId(int id);
        Task<DetalleVenta?> DeleteSaleDetailBySaleIdAndDetailsId(int id, int detailId);

        // Exists
        Task<bool> ExitSaleBySaleId(int id);
        Task<bool> ExitDetailBySaleIdAndDetailsId(int id, int detailId);
    }
}
