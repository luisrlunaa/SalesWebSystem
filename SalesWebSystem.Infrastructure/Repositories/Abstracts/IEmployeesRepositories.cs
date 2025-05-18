using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IEmployeesRepositories
    {
        // List
        Task<List<Empleado>> EmployeesList();
        Task<List<Cargo>> ChargesList();
        Task<List<Empleado>> EmployeesListByChargeId(int chargeId);

        // Get
        Task<Empleado?> EmployeeByEmployeeId(int id);
        Task<Empleado?> EmployeeByEmail(string email);
        Task<Cargo?> ChargeById(int id);

        // Add
        Task<Empleado> AddEmployee(Empleado employee);
        Task<Cargo> AddCharge(Cargo charge);

        // Update
        Task<Empleado> UpdateEmployee(Empleado employee);
        Task<Cargo> UpdateCharge(Cargo charge);

        // Delete
        Task<Empleado?> DeleteEmployeeByEmployeeId(int id);
        Task<Cargo?> DeletChargeById(int id);

        // Exists
        Task<bool> ExitEmployeeByEmployeeId(int id);
        Task<bool> ExitEmployeeByEmail(string email);
        Task<bool> ExitChargeByDescription(string description);
    }
}
