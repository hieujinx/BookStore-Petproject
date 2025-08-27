using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DTOs.Orders
{
    public class OrderItemDto
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public decimal PriceAtPurchase { get; set; }
        public int Quantity { get; set; }
        public decimal Total => PriceAtPurchase * Quantity;
    }
}
