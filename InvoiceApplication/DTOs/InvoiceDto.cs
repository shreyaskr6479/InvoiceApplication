using InvoiceApplication.Models;

namespace InvoiceApplication.DTOs
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<ItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentOption { get; set; }
    }
}
