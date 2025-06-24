using System.Drawing.Printing;
using LibrarySystemWeb.Data;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWeb.Views.Shared.Components.MyBooksList
{
    [Authorize]
    public class MyBooksListViewComponent : ViewComponent
    {
        private readonly BooksService _booksService;
        private readonly LibrarySystemContext _db;

        public MyBooksListViewComponent(BooksService booksService, LibrarySystemContext db)
        {
            _booksService = booksService;
            _db = db;
        }

        [Authorize]
        public IViewComponentResult Invoke(int pageNum = 1)
        {
            if (HttpContext.Request.Query.ContainsKey("pageNum"))
            {
                if (int.TryParse(HttpContext.Request.Query["pageNum"], out int parsedPageNum))
                {
                    pageNum = parsedPageNum;
                }
            }

            var userIdClaim = HttpContext.User.FindFirst("UserId");

            int userId = -1;
            if (userIdClaim != null)
            {
                userId = int.Parse(userIdClaim.Value);
            }
            else
            {
                MyBooksListViewModel errModel = new MyBooksListViewModel()
                {
                    errMsg = "Something went wrong"
                };

                return View(errModel);

            }



            int perPage = 30;

            int count = _db.Borrows.Select(x => x.UserId == userId && x.ActualReturnDate != null).Count();

            int maxPages = (int)Math.Ceiling((double)count / 30);


            Console.WriteLine($"Page Number: {pageNum}\n" +
                $"UserId: {userId}\n" +
                $"Count: {count}\n" +
                $"maxPages: {maxPages}\n\n");



            MyBooksListViewModel model = new MyBooksListViewModel()
            {
                pageNum = pageNum,
                currentPage = pageNum,
                maxPages = maxPages,
                errMsg = null!
            };

            if (pageNum > maxPages || pageNum < 1)
            {
                pageNum = 1;
            }


            var borrowedBooks = _db.Borrows
                .Where(borrow => borrow.UserId == userId && borrow.ActualReturnDate == null)
                .Include(borrow => borrow.Book)
                .OrderBy(borrow => borrow.ScheduleReturnDate) // Order by ScheduleReturnDate descending
                .Skip((pageNum - 1) * perPage) // Apply Skip for pagination
                .Take(perPage) // Apply Take for pagination
                .ToList();

            var result = borrowedBooks.Select(borrow => (borrow.Book, borrow)).ToList();


            model.myBooks = result;



            return View(model);
        }
    }
}