using BookStore.Application.DTOs.Orders;
using BookStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Mappers.Orders
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToDto(OrderItem item)
        {
            return new OrderItemDto
            {
                BookId = item.BookId,
                BookTitle = item.Book?.Title ?? string.Empty,
                PriceAtPurchase = item.PriceAtPurchase,
                Quantity = item.Quantity
            };
        }

        public static OrderItem ToEntity(CreateOrderItemDto dto)
        {
            return new OrderItem
            {
                BookId = dto.BookId,
                Quantity = dto.Quantity
            };
        }
    }

}
