namespace LibrarySystemWeb.Models
{
    public class MyBooksListViewModel
    {
        public int pageNum { get; set; } = 1;
        public int currentPage { get; set; } = 0;
        public int maxPages { get; set; } = 0;
        public string errMsg { get; set; } = null!;

        public List<(Book book, Borrow borrow)>? myBooks { get; set; } = new List<(Book book, Borrow borrow)>();
    }
}
