using BookStore.Application.DTOs.Books;
using BookStore.Domain.Entities;

namespace BookStore.Application.Mappers.Books
{
    public static class BookMapper
    {
        // Entity -> BookDto
        public static BookDto ToDto(Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
                Stock = book.Stock,
                ISBN = book.ISBN,
                ImageUrl = book.ImageUrl,
                CreatedAt = book.CreatedAt,
                UpdatedAt = book.UpdatedAt,
                IsActive = book.IsActive
            };
        }

        // CreateBookDto -> Entity
        public static Book ToEntity(CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                ISBN = dto.ISBN,
                ImageUrl = dto.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        // UpdateBookDto -> cập nhật vào Entity đã có
        public static void UpdateEntity(Book book, UpdateBookDto dto)
        {
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Description = dto.Description;
            book.Price = dto.Price;
            book.Stock = dto.Stock;
            book.ISBN = dto.ISBN;
            book.ImageUrl = dto.ImageUrl;
            book.UpdatedAt = DateTime.UtcNow;
        }
    }
}
