using LibrarySystemWeb.Data;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystemWeb.Views.Shared.Components.BookSearch
{
    public class BookSearchViewComponent : ViewComponent
    {
        private readonly BooksService _booksService;
        private readonly LibrarySystemContext _db;

        public BookSearchViewComponent(BooksService booksService, LibrarySystemContext db)
        {
            _booksService = booksService;
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int pageNum = 1, int searchType = 1, string searchText = "")
        {


            Console.WriteLine(" \n\n\nINVOKED\n\n\n");


            Console.WriteLine($"BE - pageNum: {pageNum},  searchType: {searchType},  searchText: {searchText}.");
            int pageSize = 20; // Number of items per page

            // Ensure search text is valid
            string search = string.IsNullOrEmpty(searchText) ? "" : searchText;



            var totalCount = _db.SearchResults
            .FromSqlRaw("EXEC sp_FetchBooks_Simple @p0, @p1", searchType, search)
            .AsEnumerable()
            .Count();
            Console.WriteLine("TotalCount" + totalCount.ToString());

            // Get paginated book list
            var books = await _db.SearchResults
                .FromSqlRaw("EXEC sp_FetchBooks_Search_Only @page_number = @p0, @is_available = @p1, @page_size = @p2, @search_text = @p3",
                            pageNum, searchType, pageSize, search)
                .ToListAsync();

            Console.WriteLine("TotalCount" + books.ToString());

            var model = new BookSearchViewModel
            {
                Books = books,
                TotalCount = totalCount,
                CurrentPage = pageNum,
                PageSize = pageSize,
                SearchType = searchType,
                SearchText = searchText
            };

            return View(model);
        }

    }
}
