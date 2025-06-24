using LibrarySystemWeb.Data;
using Microsoft.EntityFrameworkCore;
using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Services
{
    public class BooksService
    {
        private readonly LibrarySystemContext _context;

        public BooksService(LibrarySystemContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync(int count = 10)
        {
            // Fetch top 'count' books from the database
            return await _context.Books
                .OrderBy(b => b.CreatedAt) 
                .Take(count).ToListAsync();
        }

        public async Task<(List<Book> Books, int TotalCount)> GetBooksPaginatedAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Calculate the total number of books in the database
            int totalCount = await _context.Books.CountAsync();

            // Fetch books for the current page
            var books = await _context.Books
                .OrderBy(b => b.CreatedAt) // or another ordering field
                .Skip((pageNumber - 1) * pageSize) // Skip previous pages
                .Take(pageSize) // Take the number of items for the current page
                .ToListAsync();

            return (books, totalCount);
        }

    }
}
