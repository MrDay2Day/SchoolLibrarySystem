using System;
using System.Collections.Generic;
using LibrarySystemWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWeb.Data;

public partial class LibrarySystemContext : DbContext
{
    public LibrarySystemContext()
    {
    }

    public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrow> Borrows { get; set; }

    public virtual DbSet<LateFeePayment> LateFeePayments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public DbSet<SearchResult> SearchResults { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=23.95.235.16;Database=Library_System;User Id=vtdi_student;Password=P@ssword1;MultipleActiveResultSets=true;Encrypt=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SearchResult>().HasNoKey();

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__C220CF9C69D4F566");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateBooks_Timestamp"));

            entity.HasIndex(e => e.Title, "IX_Book_Name");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.Author).HasMaxLength(255);
            entity.Property(e => e.Available).HasDefaultValue(true);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Borrow>(entity =>
        {
            entity.HasKey(e => e.BorrowId).HasName("PK__Borrows__B7FB20A4C1B6A774");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateBorrows_Timestamp"));

            entity.Property(e => e.BorrowId).HasColumnName("Borrow_id");
            entity.Property(e => e.ActualReturnDate).HasColumnName("Actual_return_date");
            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.BorrowDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Borrow_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.ScheduleReturnDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("Schedule_return_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__Borrows__Book_id__797309D9");

            entity.HasOne(d => d.User).WithMany(p => p.Borrows)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Borrows__User_id__787EE5A0");
        });

        modelBuilder.Entity<LateFeePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__LateFeeP__DA638B19AB1F2D92");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateLateFeePayments_Timestamp"));

            entity.Property(e => e.PaymentId).HasColumnName("Payment_id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BorrowId).HasColumnName("Borrow_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Borrow).WithMany(p => p.LateFeePayments)
                .HasForeignKey(d => d.BorrowId)
                .HasConstraintName("FK__LateFeePa__Borro__7F2BE32F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206A9DF871009A70");

            entity.ToTable(tb => tb.HasTrigger("trg_UpdateUsers_Timestamp"));

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F4DC8E62").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .HasColumnName("Last_name");
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(11);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasDefaultValue("USER");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
