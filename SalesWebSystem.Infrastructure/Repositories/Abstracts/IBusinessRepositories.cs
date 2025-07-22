using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IBusinessRepositories
    {
        // List
        Task<List<Caja>> BoxesList();
        Task<List<Caja?>> BoxesBybusinessId(int businessId);
        Task<List<Cuadre>> CashBalanceList(int businessId);
        Task<List<Licencia>> LicensesList();
        Task<List<NomEmp>> BusinessInfoList();

        // Get
        Task<Caja?> LastBox();
        Task<Caja?> BoxById(int id);
        Task<Caja?> LastBoxIdbusinessId(int businessId);
        Task<Caja?> BoxByIdbusinessId(int id, int businessId);
        Task<Cuadre?> CashBalanceById(int id);
        Task<Cuadre?> CashBalanceByIdbusinessId(int id, int businessId);
        Task<Cuadre?> CashBalanceByDatebusinessId(int businessId, DateTime date);
        Task<Licencia?> LicenseById(int id);
        Task<NomEmp?> BusinessInfoById(int id);


        // Add
        Task<Caja> AddBox(Caja input);
        Task<Cuadre> AddCashBalance(Cuadre input);
        Task<Licencia> AddLicense(Licencia input);
        Task<NomEmp> AddBusinessInfo(NomEmp input);

        // Update
        Task<Caja> UpdateBox(Caja input);
        Task<Cuadre> UpdateCashBalance(Cuadre input);
        Task<Licencia> UpdateLicense(Licencia input);
        Task<NomEmp> UpdateBusinessInfo(NomEmp input);

        // Delete
        Task<bool> DeleteBoxById(int id, int businessId);
        Task<bool> DeleteCashBalanceById(int id, int businessId);
        Task<bool> DeleteLicenseById(int id);
        Task<bool> DeleteBusinessInfoById(int id);

        // Exists
        Task<bool> ExitBoxById(int id, int businessId);
        Task<bool> ExitCashBalanceById(int id, int businessId);
        Task<bool> ExitLicenseById(int id);
        Task<bool> ExitBusinessInfoById(int id);
    }
}