using AutoMapper;
using InvoiceApplication.Data;
using InvoiceApplication.DTOs;
using InvoiceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Container
{
    public class ProductContainer : IProductContainer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductContainer(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var customers = await _context.Products.Include(p => p.Category).ToListAsync();

            if (customers != null && customers.Count > 0)
            {
                return this._mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(customers);
            }
            return Enumerable.Empty<ProductDto>();
        }

        public async Task<ProductDto?> GetProductByProductId(int productId)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(c => c.Id == productId);

            if (product != null)
            {
                return this._mapper.Map<Product, ProductDto>(product);
            }
            return null;
        }

        public async Task UpdateProduct(ProductDto product)
        {
            _context.Entry(this._mapper.Map<ProductDto, Product>(product)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddProduct(ProductDto product)
        {
            _context.Products.Add(this._mapper.Map<ProductDto, Product>(product));
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public bool IsProductExists(int productId)
        {
            return _context.Products.Any(e => e.Id == productId);
        }

        public bool IsCategoryExists(int categoryId)
        {
            return _context.Categories.Any(e => e.Id == categoryId);
        }

        public async Task<Product?> GetProductToDeleteByProductId(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == productId);
        }
    }
}