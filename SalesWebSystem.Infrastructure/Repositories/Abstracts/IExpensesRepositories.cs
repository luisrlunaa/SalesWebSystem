using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IExpensesRepositories
    {
        // List
        Task<List<Gastos>> ExpensesList();

        // Get
        Task<Gastos?> ExpenseByExpenseId(int id);

        // Add
        Task<Gastos> AddExpense(Gastos Expense);

        // Update
        Task<Gastos> UpdateExpense(Gastos Expense);

        // Delete
        Task<Gastos?> DeleteExpenseByExpenseId(int id);

        // Exists
        Task<bool> ExitExpenseByExpenseId(int id);
    }
}
