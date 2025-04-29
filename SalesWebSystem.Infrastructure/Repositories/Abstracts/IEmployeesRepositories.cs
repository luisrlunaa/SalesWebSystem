using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IEmployeesRepositories
    {
        // List
        Task<List<Empleado>> EmployeesList();
        Task<List<Empleado>> EmployeesListByChargeId(int chargeId);

        // Get
        Task<Empleado?> EmployeeByEmployeeId(int id);
        Task<Empleado?> EmployeeByEmail(string email);

        // Add
        Task<Empleado> AddEmployee(Empleado employee);

        // Update
        Task<Empleado> UpdateEmployee(Empleado employee);

        // Delete
        Task<Empleado?> DeleteEmployeeByEmployeeId(int id);

        // Exists
        Task<bool> ExitEmployeeByEmployeeId(int id);
        Task<bool> ExitEmployeeByEmail(string email);
    }
}
