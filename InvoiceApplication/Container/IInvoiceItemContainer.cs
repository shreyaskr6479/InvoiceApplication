using InvoiceApplication.DTOs;
using InvoiceApplication.Models;

namespace InvoiceApplication.Container
{
    public interface IInvoiceItemContainer
    {
        public Task UpdateInvoiceItemQuantity(InvoiceItemDto invoiceItem);

        public Task AddInvoiceItemToCart(InvoiceItemDto invoiceItem, Product product);

        public Task DeleteInvoiceItemFromCart(InvoiceItem invoiceItem, Product product);

        public bool IsItemQuantitySame(InvoiceItemDto invoiceItem);

        public Task<InvoiceItem?> GetItemToDeleteByInvoiceId(int invoiceItemId);

        public Task<Customer?> GetCustomerByCustomerId(int customerId);

        public Task<Product?> GetProductByProductId(int productId);

        public Task<List<InvoiceItem>> GetCartItemsForCustomer(int customerId);

        public Task<InvoiceDto> GetInvoice(Customer customer, List<InvoiceItem> invoiceItems, string paymentOption);
    }
}
