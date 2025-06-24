using LibrarySystemWeb.Data;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Drawing.Printing;

namespace LibrarySystemWeb.Controllers
{
    public class BorrowController : Controller
    {
        private readonly LibrarySystemContext _context;
        private readonly BooksService _booksService;

        public BorrowController(LibrarySystemContext context, BooksService booksService)
        {
            _context = context;
            _booksService = booksService;
        }

        [HttpGet]
        [Authorize]
        public  IActionResult MyBooks(int pageNum = 1)
        {
            MyBooksListViewModel model = new ()
            {
                pageNum = 1
            };

            return View("MyBooks");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BorrowAsync(int bookId, int pageNumber = 1, int pageSize = 10)
        {
            var (books, totalCount) = await _booksService.GetBooksPaginatedAsync(pageNumber, pageSize);
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            Console.WriteLine($"BookId: {bookId}");
            Book book = await _context.Books.FindAsync(bookId); // Use FindAsync
            if (book == null)
            {
                return NotFound("Book not found."); // Return a 404 if the book is not found
            }

            BorrowPageModel model = new BorrowPageModel()
            {
                book = book,
                Books = books,
            };
            return View("Borrow", model);
        }

        [HttpPost]
        [Authorize] // Ensure that only authenticated users can borrow
        public async Task<IActionResult> Borrow(BorrowPageModel model)
        {

            Console.WriteLine("Model Data:");
            Console.WriteLine($"  book: {model.book}"); // Consider logging book properties if needed
            Console.WriteLine($"  borrowed: {model.borrowed}");
            Console.WriteLine($"  success: {model.success}");
            Console.WriteLine($"  Books: {model.Books}"); // Consider logging book list if needed
            Console.WriteLine($"  message: {model.message}");
            Console.WriteLine($"  Days: {model.Days}");

            //if (!ModelState.IsValid)
            //{
            //    return View("Borrow", model);
            //}

            try
            {
                var userIdClaim = User.FindFirst("UserId");
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    model.message = "Invalid or missing user ID.";
                    model.success = false;
                    return View("Borrow", model);
                }

                var book = await _context.Books.FindAsync(model.book.BookId);
                if (book == null)
                {
                    model.message = "Book not found.";
                    model.success = false;
                    return View("Borrow", model);
                }

                if (!book.Available)
                {
                    model.message = "This book is no longer available.";
                    model.success = false;
                    return View("Borrow", model);
                }

                var borrowDate = DateTime.Now;
                var returnDate = borrowDate.AddDays(model.Days);

                var borrowing = new Borrow
                {
                    BookId = model.book.BookId,
                    UserId = userId,
                    BorrowDate = borrowDate,
                    ScheduleReturnDate = returnDate,
                };

                _context.Borrows.Add(borrowing);
                book.Available = false;
                _context.Books.Update(book);

                await _context.SaveChangesAsync();

                var (books, totalCount) = await _booksService.GetBooksPaginatedAsync(1, 20);

                Console.WriteLine("\n\nHERE\n\n");

                model.message = "\""+book.Title+ "\"" + " was reserved successfully!";
                model.success = true;
                model.book = book;
                model.Books = books;

                return View("Borrow", model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                model.message = $"Error: {ex.Message}";
                model.success = false;
                return View("Borrow", model);
            }
        }
    }
}