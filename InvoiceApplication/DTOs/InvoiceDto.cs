using InvoiceApplication.Models;

namespace InvoiceApplication.DTOs
{
    public class InvoiceDto
    {
        public Customer Customer { get; set; }
        public List<ItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentOption { get; set; }
    }
}