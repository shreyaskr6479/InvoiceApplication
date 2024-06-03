using InvoiceApplication.DTOs;
using InvoiceApplication.Models;

namespace InvoiceApplication.Container
{
    public interface ICategoryContainer
    {
        public Task<IEnumerable<CategoryDto>> GetCategories();

        public Task<CategoryDto?> GetCategoryByCategoryId(int categoryId);

        public Task UpdateCategory(Category category);

        public Task AddCategory(Category category);

        public Task DeleteCategory(Category category);

        public bool IsCategoryExists(int categoryId);

        public Task<Category?> GetCategoryToDeleteByCategoryId(int categoryId);
    }
}
