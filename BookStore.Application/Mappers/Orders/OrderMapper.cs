using BookStore.Domain.Entities;
using BookStore.Application.DTOs.Orders;

public static class OrderMapper
{
    // Entity → DTO
    public static OrderDto ToDto(Order order)
    {
        return new OrderDto
        {
            Id = order.Id,
            UserId = order.UserId,
            Total = order.Total,
            Status = order.Status,
            OrderDate = order.OrderDate,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt,
            OrderItems = order.OrderItems?.Select(ToOrderItemDto).ToList() ?? new()
        };
    }

    // Entity → DTO cho OrderItem
    public static OrderItemDto ToOrderItemDto(OrderItem item)
    {
        return new OrderItemDto
        {
            BookId = item.BookId,
            BookTitle = item.Book?.Title ?? string.Empty,
            PriceAtPurchase = item.PriceAtPurchase,
            Quantity = item.Quantity
        };
    }

    // DTO → Entity khi tạo mới Order
    public static Order ToEntity(CreateOrderDto dto)
    {
        return new Order
        {
            UserId = dto.UserId,
            Status = "Pending",
            OrderDate = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            OrderItems = dto.OrderItems.Select(ToOrderItemEntity).ToList(),
            Total = 0 // Sẽ tính lại sau trong Service
        };
    }

    // DTO → OrderItem (khi tạo mới)
    public static OrderItem ToOrderItemEntity(CreateOrderItemDto dto)
    {
        return new OrderItem
        {
            BookId = dto.BookId,
            Quantity = dto.Quantity
            // PriceAtPurchase sẽ được set trong Service
        };
    }
}
