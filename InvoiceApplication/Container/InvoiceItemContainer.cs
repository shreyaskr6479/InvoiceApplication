using AutoMapper;
using InvoiceApplication.Data;
using InvoiceApplication.DTOs;
using InvoiceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Container
{
    public class InvoiceItemContainer : IInvoiceItemContainer
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceItemContainer(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task UpdateInvoiceItemQuantity(InvoiceItemDto invoiceItem)
        {
            _context.Entry(invoiceItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddInvoiceItemToCart(InvoiceItemDto invoiceItem, Product product)
        {
            // Calculating the total price
            var itemTotalPrice = invoiceItem.Quantity * product.Price;
            invoiceItem.TotalItemPrice = itemTotalPrice - ((invoiceItem.Discount / 100) * itemTotalPrice);

            _context.InvoiceItems.Add(this._mapper.Map<InvoiceItemDto, InvoiceItem>(invoiceItem));

            // Update product quantity
            product.Quantity -= invoiceItem.Quantity;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteInvoiceItemFromCart(InvoiceItem invoiceItem, Product product)
        {
            _context.InvoiceItems.Remove(invoiceItem);

            // Update product quantity
            product.Quantity += invoiceItem.Quantity;

            await _context.SaveChangesAsync();
        }

        public bool IsItemQuantitySame(InvoiceItemDto invoiceItem)
        {
            return _context.InvoiceItems.Any(e => e.Id == invoiceItem.Id && e.Quantity != invoiceItem.Quantity);
        }

        public async Task<InvoiceItem?> GetItemToDeleteByInvoiceId(int invoiceItemId)
        {
            return await _context.InvoiceItems.FirstOrDefaultAsync(c => c.Id == invoiceItemId);
        }

        public async Task<Customer?> GetCustomerByCustomerId(int customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
        }

        public async Task<Product?> GetProductByProductId(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(c => c.Id == productId);
        }

        public async Task<List<InvoiceItem>> GetCartItemsForCustomer(int customerId)
        {
            return await _context.InvoiceItems.Where(c => c.CustomerId == customerId).ToListAsync();
        }

        public async Task<InvoiceDto> GetInvoice(
            Customer customer, List<InvoiceItem> invoiceItems, string paymentOption)
        {
            InvoiceDto invoice = new InvoiceDto
            {
                Customer = customer,
                PaymentOption = paymentOption
            };

            invoice.Items = new List<ItemDto>();

            foreach (var item in invoiceItems)
            {
                var product = await GetProductByProductId(item.ProductId);
                if (product == null)
                {
                    return new InvoiceDto();
                }
                var category = await GetCategory(product.CategoryId);
                if (category == null)
                {
                    return new InvoiceDto();
                }

                ItemDto invoiceItem = new ItemDto
                {
                    ProductName = product.Name,
                    Category = category.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = item.Quantity,
                    Discount = item.Discount,
                    TotalItemPrice = item.TotalItemPrice
                };

                invoice.Items.Add(invoiceItem);
                invoice.TotalAmount += invoiceItem.TotalItemPrice;
            }
            return invoice;
        }

        private async Task<Category?> GetCategory(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}