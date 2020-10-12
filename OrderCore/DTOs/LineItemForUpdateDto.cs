using System.ComponentModel.DataAnnotations;

namespace OrderCore.DTOs
{
    public class LineItemForUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Order ID is required.")]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Product ID is required.")]
        public int OrderId { get; set; }
        
        public string ItemCode { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Line Items must have a quantity greater than 0.")]
        public int Quantity { get; set; }
        
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        public decimal Discount { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}