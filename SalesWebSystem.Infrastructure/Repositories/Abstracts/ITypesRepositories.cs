using SalesWebSystem.Infrastructure.Data.Entities;

namespace SalesWebSystem.Infrastructure.Repositories.Abstracts
{
    public interface ITypesRepositories
    {
        // List
        Task<List<Tipo_factura>> InvoiceTypeList();
        Task<List<Tipo_trabajo>> JobTypeList();
        Task<List<tipoGOma>> CategoryTypeList();
        Task<List<Categoria>> CategoryList();

        // Get
        Task<Tipo_factura?> InvoiceTypeById(int id);
        Task<Tipo_trabajo?> JobTypeById(int id);
        Task<tipoGOma?> CategoryTypeById(int id);
        Task<Categoria?> CategoryById(int id);

        // Add
        Task<Tipo_factura> AddInvoiceType(Tipo_factura type);
        Task<Tipo_trabajo> AddJobType(Tipo_trabajo type);
        Task<tipoGOma> AddCategoryType(tipoGOma type);
        Task<Categoria> AddCategory(Categoria category);

        // Update
        Task<Tipo_factura> UpdateInvoiceType(Tipo_factura type);
        Task<Tipo_trabajo> UpdateJobType(Tipo_trabajo type);
        Task<tipoGOma> UpdateCategoryType(tipoGOma type);
        Task<Categoria> UpdateCategory(Categoria category);

        // Delete
        Task<Tipo_factura?> DeleteInvoiceTypeBytypeId(int id);
        Task<Tipo_trabajo?> DeleteJobTypeBytypeId(int id);
        Task<tipoGOma?> DeleteCategoryTypeBytypeId(int id);
        Task<Categoria?> DeleteCategoryById(int id);

        // Exists
        Task<bool> ExitInvoiceTypeBytypeId(int id);
        Task<bool> ExitJobTypeBytypeId(int id);
        Task<bool> ExitCategoryTypeBytypeId(int id);
        Task<bool> ExitCategoryById(int id);
    }
}