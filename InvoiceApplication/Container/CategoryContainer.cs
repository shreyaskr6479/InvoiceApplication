using InvoiceApplication.Data;
using InvoiceApplication.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using InvoiceApplication.DTOs;

namespace InvoiceApplication.Container
{
    public class CategoryContainer : ICategoryContainer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryContainer(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            if (categories != null && categories.Count > 0)
            { 
                return this._mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDto>>(categories);
            }
            return Enumerable.Empty<CategoryDto>();
        }

        public async Task<CategoryDto?> GetCategoryByCategoryId(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category != null)
            {
                return this._mapper.Map<Category, CategoryDto>(category);
            }
            return null;
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public bool IsCategoryExists(int categoryId)
        {
            return _context.Categories.Any(e => e.Id == categoryId);
        }

        public async Task<Category?> GetCategoryToDeleteByCategoryId(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
