namespace InvoiceApplication.DTOs
{
    public class ItemDto
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Decimal Discount { get; set; }
        public Decimal TotalItemPrice { get; set; }
    }
}
