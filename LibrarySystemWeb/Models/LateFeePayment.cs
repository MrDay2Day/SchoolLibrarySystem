using System;
using System.Collections.Generic;

namespace LibrarySystemWeb.Models;

public partial class LateFeePayment
{
    public int PaymentId { get; set; }

    public int BorrowId { get; set; }

    public decimal Amount { get; set; }

    public bool Paid { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Borrow Borrow { get; set; } = null!;
}
