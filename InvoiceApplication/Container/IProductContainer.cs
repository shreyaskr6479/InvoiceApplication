using InvoiceApplication.Models;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Container
{
    public interface IProductContainer
    {
        public Task<IEnumerable<ProductDto>> GetProducts();

        public Task<ProductDto?> GetProductByProductId(int productId);

        public Task UpdateProduct(ProductDto product);

        public Task AddProduct(ProductDto product);

        public Task DeleteProduct(Product product);

        public bool IsProductExists(int productId);

        public bool IsCategoryExists(int categoryId);

        public Task<Product?> GetProductToDeleteByProductId(int productId);
    }
}
