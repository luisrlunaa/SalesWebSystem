using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class ExpensesRepositories : DataTransactionManager, IExpensesRepositories
    {
        public ExpensesRepositories(InvSysContext context) : base(context) { }


        // List
        public async Task<List<Gastos>> ExpensesList() =>
            await _context.Gastos.ToListAsync();

        // Get
        public async Task<Gastos?> ExpenseByExpenseId(int id) =>
            await _context.Gastos.FirstOrDefaultAsync(x => x.id == id);

        // Add
        public async Task<Gastos> AddExpense(Gastos Expense)
        {
            await _context.Gastos.AddAsync(Expense);
            var committed = await CommitTransactionAsync();
            return committed ? Expense : null;
        }

        // Update
        public async Task<Gastos> UpdateExpense(Gastos Expense)
        {
            _context.Gastos.Update(Expense);
            var committed = await CommitTransactionAsync();
            return committed ? Expense : null;
        }

        // Delete
        public async Task<Gastos?> DeleteExpenseByExpenseId(int id)
        {
            var Expense = await ExpenseByExpenseId(id);
            if (Expense is null)
                return null;

            _context.Gastos.Remove(Expense);
            var committed = await CommitTransactionAsync();
            return committed ? Expense : null;
        }

        // Exists
        public async Task<bool> ExitExpenseByExpenseId(int id) =>
            await _context.Gastos.AnyAsync(x => x.id == id);
    }
}
