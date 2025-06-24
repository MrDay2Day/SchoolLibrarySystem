namespace LibrarySystemWeb.Models
{
    public class BorrowViewModel
    {
        public int User_id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int BorrowDays { get; set; }
    }
}