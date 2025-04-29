using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class EmployeesRepositories : DataTransactionManager, IEmployeesRepositories
    {
        public EmployeesRepositories(InvSysContext context) : base(context) { }

        // List
        public async Task<List<Empleado>> EmployeesList() =>
            await _context.Empleados.ToListAsync();

        public async Task<List<Empleado>> EmployeesListByChargeId(int chargeId) =>
            await _context.Empleados.Where(x => x.IdCargo == chargeId).ToListAsync();

        // Get
        public async Task<Empleado?> EmployeeByEmployeeId(int id) =>
            await _context.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == id);

        public async Task<Empleado?> EmployeeByEmail(string email) =>
            await _context.Empleados.FirstOrDefaultAsync(x => x.Correo == email);

        // Add
        public async Task<Empleado> AddEmployee(Empleado employee)
        {
            await _context.Empleados.AddAsync(employee);
            var committed = await CommitTransactionAsync();
            return committed ? employee : null;
        }

        // Update
        public async Task<Empleado> UpdateEmployee(Empleado employee)
        {
            _context.Empleados.Update(employee);
            var committed = await CommitTransactionAsync();
            return committed ? employee : null;
        }

        // Delete
        public async Task<Empleado?> DeleteEmployeeByEmployeeId(int id)
        {
            var employee = await EmployeeByEmployeeId(id);
            if (employee is null)
                return null;

            _context.Empleados.Remove(employee);
            var committed = await CommitTransactionAsync();
            return committed ? employee : null;
        }

        // Exists
        public async Task<bool> ExitEmployeeByEmployeeId(int id) =>
            await _context.Empleados.AnyAsync(x => x.IdEmpleado == id);

        public async Task<bool> ExitEmployeeByEmail(string email) =>
            await _context.Empleados.AnyAsync(x => x.Correo == email);
    }
}
