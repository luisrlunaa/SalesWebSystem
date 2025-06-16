using Microsoft.Extensions.DependencyInjection;
using SalesWebSystem.Application.Services.Abstracts;
using SalesWebSystem.Infrastructure.Repositories;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Application.Services
{
    public class ConfigurationsApp()
    {
        public void ServicesApp(IServiceCollection services)
        {
            services.AddScoped<IBusinessServices, BusinessServices>();
        }

        public void RepositoriesApp(IServiceCollection services)
        {
            services.AddScoped<IEmployeesRepositories, EmployeesRepositories>();
            services.AddScoped<IProductsRepositories, ProductsRepositories>();
            services.AddScoped<IClientsRepositories, ClientsRepositories>();
            services.AddScoped<IUsersRepositories, UsersRepositories>();
            services.AddScoped<ISalesRepositories, SalesRepositories>();
            services.AddScoped<INCFRepositories, NCFRepositories>();
            services.AddScoped<IPaymentsRepositories, PaymentsRepositories>();
            services.AddScoped<IExpensesRepositories, ExpensesRepositories>();
            services.AddScoped<ITypesRepositories, TypesRepositories>();
            services.AddScoped<IBusinessRepositories, BusinessRepositories>();
        }
    }
}