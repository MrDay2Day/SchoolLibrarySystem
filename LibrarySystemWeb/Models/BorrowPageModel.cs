using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystemWeb.Models;

public partial class BorrowPageModel
{
    public Book book { get; set; } = null!;
    public bool? borrowed { get; set; } = false;
    public bool? success { get; set; } = false;
    public List<Book> Books { get; set; } = null;
    public string message{ get; set; } = null;

    [Range(1, 14, ErrorMessage = "Days must be between 1 and 14.")]
    public int Days { get; set; } = 7;

}
