using BookStore.Domain.Entities;
using BookStore.Application.DTOs.Carts;

namespace BookStore.Application.Mappers.Carts
{
    public static class CartMapper
    {
        // Entity → DTO
        public static CartDto ToDto(Cart cart)
        {
            return new CartDto
            {
                Id = cart.Id,
                UserId = cart.UserId,
                CreatedAt = cart.CreatedAt,
                UpdatedAt = cart.UpdatedAt,
                CartItems = cart.CartItems.Select(ToCartItemDto).ToList()
            };
        }

        // Entity → DTO cho từng CartItem
        public static CartItemDto ToCartItemDto(CartItem item)
        {
            return new CartItemDto
            {
                Id = item.Id,
                BookId = item.BookId,
                BookTitle = item.Book?.Title ?? string.Empty,
                BookPrice = item.Book?.Price ?? 0,
                Quantity = item.Quantity
            };
        }

        // DTO → Entity khi thêm vào giỏ
        public static CartItem ToEntity(AddToCartDto dto, int cartId)
        {
            return new CartItem
            {
                CartId = cartId,
                BookId = dto.BookId,
                Quantity = dto.Quantity
            };
        }

        // DTO → cập nhật số lượng nếu cần (option)
        public static void UpdateEntity(CartItem entity, int newQuantity)
        {
            entity.Quantity = newQuantity;
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
