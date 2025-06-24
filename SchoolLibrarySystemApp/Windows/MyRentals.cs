using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Windows
{
    public partial class MyRentals : Form
    {
        private User systemUser;
        private Library_SystemEntities db;

        private int pageNum = 1; // Current page number
        private int perPage = 30; // Number of items per page

        private int bookIdNumber;
        private int borrowIdNumber;
        private Book selectedBook;
        private double owed;

        public MyRentals(User user)
        {
            db = new Library_SystemEntities();
            InitializeComponent();
            this.systemUser = user;
            this.WindowState = FormWindowState.Maximized;

            LoadBorrowedBooks();
        }

        private void LoadBorrowedBooks()
        {
            if (systemUser == null)
            {
                MessageBox.Show("User not set.");
                return;
            }

            try
            {
                int count = db.Borrows.Count(x => x.User_id == systemUser.User_id && x.Actual_return_date == null); //Corrected the count

                int limit = ((pageNum - 1) * perPage);

                int maxPages = (int)Math.Ceiling((double)count / perPage);

                button1.Enabled = pageNum > 1;
                button2.Enabled = pageNum < maxPages;

                tally.Text = $"{(limit + 1).ToString()} to " +
                            $"{(limit + perPage > count ? count : (limit) + perPage).ToString()} of {count}";

                var borrowedBooks = db.Borrows
                    .Where(borrow => borrow.User_id == systemUser.User_id && borrow.Actual_return_date == null)
                    .Include(borrow => borrow.Book)
                    .OrderBy(borrow => borrow.Schedule_return_date)
                    .Skip((pageNum - 1) * perPage)
                    .Take(perPage)
                    .ToList();

                var result = borrowedBooks.Select(borrow => new
                {
                    borrow.Book_id,
                    borrow.Borrow_id,
                    borrow.Book.Title,
                    borrow.Book.Author,
                    borrow.Book.Description,
                    borrow.Borrow_date,
                    borrow.Schedule_return_date,
                    Fee = CalculateFee(borrow.Schedule_return_date) //added Fee
                }).ToList();

                dgvRentals.DataSource = result;

                dgvRentals.Columns["Book_id"].Visible = false;
                dgvRentals.Columns["Borrow_id"].Visible = false;

                if (dgvRentals.Columns.Contains("Borrow_date"))
                {
                    dgvRentals.Columns["Borrow_date"].HeaderText = "Borrow Date";
                    dgvRentals.Columns["Borrow_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dgvRentals.Columns.Contains("Schedule_return_date"))
                {
                    dgvRentals.Columns["Schedule_return_date"].HeaderText = "Return Deadline";
                    dgvRentals.Columns["Schedule_return_date"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dgvRentals.Columns.Contains("Fee"))
                {
                    dgvRentals.Columns["Fee"].HeaderText = "Fee";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowed books: {ex.Message}");
            }
        }

        private string CalculateFee(DateTime scheduleReturnDate)
        {
            DateTime today = DateTime.Today;
            if (today > scheduleReturnDate)
            {
                TimeSpan difference = today - scheduleReturnDate;
                return $"${difference.Days * 250}";
            }
            else
            {
                return "-";
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (pageNum > 1)
            {
                pageNum--;
                LoadBorrowedBooks();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            pageNum++;
            LoadBorrowedBooks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnPreviousPage_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnNextPage_Click(sender, e);
        }

        private void dgvRentals_Click(object sender, EventArgs e)
        {
            try
            {                   
                if (dgvRentals.SelectedRows.Count > 0) // Ensure a row is selected
                {
                    var id = dgvRentals.SelectedRows[0].Cells["Book_id"].Value;
                    var id_borrow = dgvRentals.SelectedRows[0].Cells["Borrow_id"].Value;

                    if (id != null || id_borrow != null)
                    {
                        int bookId = int.Parse(id.ToString());
                        borrowIdNumber = int.Parse(id_borrow.ToString());

                        Console.WriteLine($"Book ID for return: {bookId} & borrowid: {borrowIdNumber}");

                        // Find the row with the matching Book_id
                        DataGridViewRow selectedRow = null;
                        foreach (DataGridViewRow row in dgvRentals.Rows)
                        {
                            if (row.Cells["Book_id"].Value != null && int.Parse(row.Cells["Book_id"].Value.ToString()) == bookId)
                            {
                                selectedRow = row;
                                break;
                            }
                        }

                        if (selectedRow != null)
                        {
                            selectedBook = db.Books.FirstOrDefault(x => x.Book_id == bookId);
                            if (selectedBook == null)
                            {
                                throw new Exception("Invalid Book");
                            }
                            bookIdNumber = bookId;
                            returnBookBtn.Visible = true;
                            returnBookBtn.Enabled = true;
                            clearBookbtn.Visible = true;
                            clearBookbtn.Enabled = true;
                            textBox1.Text = selectedRow.Cells["Title"].Value?.ToString();
                            textBox2.Text = selectedRow.Cells["Author"].Value?.ToString();
                            textBox3.Text = selectedRow.Cells["Description"].Value?.ToString();

                            // Correct date parsing and formatting
                            if (selectedRow.Cells["Schedule_return_date"].Value != null && selectedRow.Cells["Schedule_return_date"].Value != DBNull.Value)
                            {
                                if (selectedRow.Cells["Schedule_return_date"].Value is DateTime scheduleReturnDate)
                                {
                                    textBox4.Text = scheduleReturnDate.ToString("yyyy-MM-dd"); // Format as yyyy-MM-dd
                                }
                                else if (selectedRow.Cells["Schedule_return_date"].Value is string dateString)
                                {
                                    DateTime parsedDate;
                                    if (DateTime.TryParse(dateString, out parsedDate))
                                    {
                                        textBox4.Text = parsedDate.ToString("yyyy-MM-dd");
                                    }
                                    else
                                    {
                                        textBox4.Text = "Invalid Date"; // Handle invalid date strings
                                    }
                                }
                                else
                                {
                                    textBox4.Text = "Unknown Date Type"; // Handle other unexpected types
                                }
                            }
                            else
                            {
                                textBox4.Text = ""; 
                            }


                            string fee = selectedRow.Cells["Fee"].Value?.ToString();
                            Console.WriteLine("Fee: " + fee);

                            if (!string.IsNullOrEmpty(fee))
                            {
                                string feePart = fee; 

                                if (fee.Contains("$"))
                                {
                                    feePart = fee.Split('$')[1];
                                    Console.WriteLine("feePart: " + feePart);
                                }

                                if (double.TryParse(feePart, out double parsedFee))
                                {
                                    owed = parsedFee;
                                }
                            }

                            feeLabel.Text = fee;
                        }
                        else
                        {
                            //MessageBox.Show("Book ID not found in DataGridView.");

                            using (WarningPopUp warning = (new WarningPopUp("Book Error", "Book Reference Error", $"Book ID not found in DataGridView.")))
                            {
                                if (warning.ShowDialog() == DialogResult.OK)
                                {
                                    //
                                };
                            }
                        }
                    }
                }

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                using (WarningPopUp warning = (new WarningPopUp("System Error", "Critial System Error", $"System Error please contact support Code: 34853237.")))
                {
                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        //
                    };
                }
            }
        }

        private void clearBookbtn_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            bookIdNumber = -1;
            borrowIdNumber = -1;
            selectedBook = null;
            returnBookBtn.Visible = false;
            returnBookBtn.Enabled = false;
            clearBookbtn.Visible = false;
            clearBookbtn.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            feeLabel.Text = "-";
            owed = 0;
        }

        private void makePayment(double amount)
        {
            using (Payment paymentForm = (new Payment(amount)))
            {
                if(paymentForm.ShowDialog() == DialogResult.OK)
                {
                    returnBook();
                }
                else
                {
                    using (WarningPopUp warning = (new WarningPopUp("Payment Error", "Unable to Process", $"Unable to precess payment if this issue continues please contact support Code: 349374637.")))
                    {
                        if (warning.ShowDialog() == DialogResult.OK)
                        {
                            //
                        };
                    }
                }
            }
        }

        private void returnBookPrompt()
        {
            using (ConfirmModal confirmDelete = (new ConfirmModal("Return Book", "Returning Book", $"You are about to return {selectedBook.Title} by {selectedBook.Author}. This action cannot be undone! Are you sure you want to continue with this action?")))
            {
                if (confirmDelete.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Owed: " + owed);
                    if (owed > 0)
                    {
                        makePayment(owed);
                    }
                    else
                    {
                        returnBook(); 
                    }
                    //
                };
            }
        }

        private void returnBook()
        {
            try
            {
                decimal decimalFee = Decimal.Parse(owed.ToString());
                Console.WriteLine("Borrow ID: " + borrowIdNumber + " " + decimalFee);

                // Assuming sp_ReturnBook returns 1 for success, 0 for failure
                var result = db.sp_ReturnBook(borrowIdNumber, decimalFee).FirstOrDefault(); //get first value.

                if (result != null) // Check if the stored procedure succeeded
                {
                    if (owed > 0)
                    {
                        // Verify if a LateFeePayment record exists.
                        LateFeePayment lateFeePayment = db.LateFeePayments.FirstOrDefault(lfp => lfp.Borrow_id == borrowIdNumber);

                        if (lateFeePayment != null)
                        {
                            lateFeePayment.Paid = true;
                            db.SaveChanges();
                        }
                        else
                        {
                            // Handle the case where a late fee was expected but not found.
                            Console.WriteLine($"Warning: Late fee expected for Borrow_id {borrowIdNumber}, but no LateFeePayment record found.");
                        }
                    }

                    using (WarningPopUp warning = new WarningPopUp("Success", "Return Successful!", $"{selectedBook.Title} by {selectedBook.Author} was returned successfully - {DateTime.Now:D}"))
                    {
                        if (warning.ShowDialog() == DialogResult.OK)
                        {
                        }
                        clear();
                        pageNum = 1;
                        LoadBorrowedBooks();
                    }
                }
                else
                {
                    // Handle the case where the stored procedure failed.
                    using (WarningPopUp warning = new WarningPopUp("Return Failed", "Return Failed", "The book return operation failed. Please try again."))
                    {
                        warning.ShowDialog();
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);

                using (WarningPopUp warning = new WarningPopUp("System Error", "System Error", $"System error please contact support. Code: TR4868237 \n{err.Message}"))
                {
                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
        }
        private void returnBookBtn_Click(object sender, EventArgs e)
        {
                returnBookPrompt();         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pageNum = 1;
            clear();
            LoadBorrowedBooks();
        }
    }
}