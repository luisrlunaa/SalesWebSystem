using Microsoft.EntityFrameworkCore;
using SalesWebSystem.Infrastructure.Data.Contexts;
using SalesWebSystem.Infrastructure.Data.Entities;
using SalesWebSystem.Infrastructure.Repositories.Abstracts;

namespace SalesWebSystem.Infrastructure.Repositories
{
    public class ProductsRepositories : DataTransactionManager, IProductsRepositories
    {
        public ProductsRepositories(InvSysContext context) : base(context) { }

        // List
        public async Task<List<Producto>> ProductsList() =>
            await _context.Productos.ToListAsync();

        public async Task<List<Producto>> ProductsListByCategoryId(int categoryId) =>
            await _context.Productos.Where(x => x.IdCategoria == categoryId).ToListAsync();

        public async Task<List<Producto>> ProductsListByType(string type) =>
            await _context.Productos.Where(x => x.TipoGoma == type).ToListAsync();

        // Get
        public async Task<Producto?> ProductByProductId(int id) =>
            await _context.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);

        public async Task<Producto?> ProductByProductName(string productName) =>
            await _context.Productos.FirstOrDefaultAsync(x => x.Nombre == productName);

        // Add
        public async Task<Producto> AddProduct(Producto Product)
        {
            await _context.Productos.AddAsync(Product);
            var committed = await CommitTransactionAsync();
            return committed ? Product : null;
        }

        // Update
        public async Task<Producto> UpdateProduct(Producto Product)
        {
            _context.Productos.Update(Product);
            var committed = await CommitTransactionAsync();
            return committed ? Product : null;
        }

        // Delete
        public async Task<Producto?> DeleteProductByProductId(int id)
        {
            var Product = await ProductByProductId(id);
            if (Product is null)
                return null;

            _context.Productos.Remove(Product);
            var committed = await CommitTransactionAsync();
            return committed ? Product : null;
        }

        // Exists
        public async Task<bool> ExitProductByProductId(int id) =>
            await _context.Productos.AnyAsync(x => x.IdProducto == id);

        public async Task<bool> ExitProductByproductName(string productName) =>
            await _context.Productos.AnyAsync(x => x.Nombre == productName);
    }
}
