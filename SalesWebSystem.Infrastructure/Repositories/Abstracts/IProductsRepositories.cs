using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface IProductsRepositories
    {
        // List
        Task<List<Producto>> ProductsList();
        Task<List<Producto>> ProductsListByCategoryId(int categoryId);
        Task<List<Producto>> ProductsListByType(string type);

        // Get
        Task<Producto?> ProductByProductId(int id);
        Task<Producto?> ProductByProductName(string productName);

        // Add
        Task<Producto> AddProduct(Producto Product);

        // Update
        Task<Producto> UpdateProduct(Producto Product);

        // Delete
        Task<Producto?> DeleteProductByProductId(int id);

        // Exists
        Task<bool> ExitProductByProductId(int id);
        Task<bool> ExitProductByproductName(string productName);
    }
}
