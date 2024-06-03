namespace InvoiceApplication.Models
{
    public class InvoiceItem 
    {
        public int Id { get; set; } 
        public int CustomerId { get; set; }
        public int ProductId { get; set; } 
        public Product Product { get; set; }
        public int Quantity { get; set; } 
        public decimal Discount { get; set; }
        public decimal TotalItemPrice { get; set; }
    }
}