using BookStore.Domain.Entities;
using BookStore.Application.DTOs.Carts;

namespace BookStore.Application.Mappers.Carts
{
    public static class CartItemMapper
    {
        // Entity → DTO
        public static CartItemDto ToDto(CartItem item)
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

        // AddToCartDto → CartItem Entity (khi thêm mới)
        public static CartItem ToEntity(AddToCartDto dto, int cartId)
        {
            return new CartItem
            {
                CartId = cartId,
                BookId = dto.BookId,
                Quantity = dto.Quantity,
                CreatedAt = DateTime.UtcNow
            };
        }

        // Cập nhật entity hiện có (sửa số lượng)
        public static void UpdateEntity(CartItem entity, int newQuantity)
        {
            entity.Quantity = newQuantity;
            entity.UpdatedAt = DateTime.UtcNow;
        }
    }
}
