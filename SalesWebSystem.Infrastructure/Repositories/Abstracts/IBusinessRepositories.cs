using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IBusinessRepositories
    {
        // List
        Task<List<Caja>> BoxesList();
        Task<List<Cuadre>> CashBalanceList();
        Task<List<Licencia>> LicensesList();
        Task<List<NomEmp>> BusinessInfoList();

        // Get
        Task<Caja?> BoxById(int id);
        Task<Cuadre?> CashBalanceById(int id);
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
        Task<Caja?> DeleteBoxById(int id);
        Task<Cuadre?> DeleteCashBalanceById(int id);
        Task<Licencia?> DeleteLicenseById(int id);
        Task<NomEmp?> DeleteBusinessInfoById(int id);

        // Exists
        Task<bool> ExitBoxById(int id);
        Task<bool> ExitCashBalanceById(int id);
        Task<bool> ExitLicenseById(int id);
        Task<bool> ExitBusinessInfoById(int id);
    }
}