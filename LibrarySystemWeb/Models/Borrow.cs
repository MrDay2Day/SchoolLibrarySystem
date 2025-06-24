using System;
using System.Collections.Generic;

namespace LibrarySystemWeb.Models;

public partial class Borrow
{
    public int BorrowId { get; set; }

    public int BookId { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ScheduleReturnDate { get; set; }

    public DateTime? ActualReturnDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual ICollection<LateFeePayment> LateFeePayments { get; set; } = new List<LateFeePayment>();

    public virtual User User { get; set; } = null!;
}
