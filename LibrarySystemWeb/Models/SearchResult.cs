namespace LibrarySystemWeb.Models
{
    public class SearchResult
    {
        public int Book_id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int PublishedYear { get; set; }

        public bool Available { get; set; }

        public DateTime? Borrow_date { get; set; }

        public DateTime? Schedule_return_date { get; set; }

    }
}
