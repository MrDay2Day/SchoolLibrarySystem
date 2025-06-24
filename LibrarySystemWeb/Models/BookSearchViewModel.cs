namespace LibrarySystemWeb.Models
{
    public class BookSearchViewModel
    {
        public List<SearchResult> Books { get; set; } = new List<SearchResult>();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int SearchType { get; set; }
        public string SearchText { get; set; }
    }
}
