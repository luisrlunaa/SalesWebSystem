using Microsoft.Extensions.DependencyInjection;
using SalesWebSystem.Infrastructure.Repositories;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Application.Services
{
    public class ConfigurationsApp()
    {
        public void ServicesApp(IServiceCollection services)
        {
            //services.AddScoped<IServicioConsultasDgii, ServicioConsultasWebDgii>();
        }

        public void RepositoriesApp(IServiceCollection services)
        {
            services.AddScoped<IEmployeesRepositories, EmployeesRepositories>();
            services.AddScoped<IProductsRepositories, ProductsRepositories>();
            services.AddScoped<IClientsRepositories, ClientsRepositories>();
            services.AddScoped<IUsersRepositories, UsersRepositories>();
        }
    }
}