namespace OrderCore.DTOs
{
    public class LineItemForUpdateDto
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }
        
        public string ItemCode { get; set; }
        
        public int Quantity { get; set; }
        
        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}