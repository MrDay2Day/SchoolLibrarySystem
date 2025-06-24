using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.Windows
{
    public partial class ViewAll : Form
    {
        private Library_SystemEntities db;

        private List<Book> books;
        private User systemUser = null;
        private Book selectedBook = null;

        private string searchText = null;
        private int pageNumber = 1;
        private int total = 0;
        private int availableCount = 0;
        private int notAvailableCount = 0;
        private int searchType = 1; // 1: All, 2: Available Only, 3: Not Available
        private int maxSearchContent = 50;

        private bool editMode = false;
        private bool newBookMode = false;

        public ViewAll(User user)
        {
            InitializeComponent();
            db = new Library_SystemEntities();
            this.WindowState = FormWindowState.Maximized;
            LoadBooks();
            this.systemUser = user;

            type_selection.DisplayMember = "Text"; // What the user sees
            type_selection.ValueMember = "Value"; // The associated value

            type_selection.DataSource = new ArrayList
            {
                new { Text = "All", Value = 1 },
                new { Text = "Available", Value = 2 },
                new { Text = "Not Available", Value = 3 }
            };

            type_selection.DropDownStyle = ComboBoxStyle.DropDownList;

            type_selection.SelectedIndex = 0;

            if (systemUser.Type == "STAFF" || systemUser.Type == "ADMIN")
            {
                btn_new_book.Enabled = true;
                btn_new_book.Visible = true;
            }

        }

        private void setAvailableOrNot()
        {
            this.availableCount = db.Books.Count(b => b.Available == true);
            this.count_available.Text = this.availableCount.ToString();

            this.notAvailableCount = db.Books.Count(b => b.Available == false);
            this.count_not_available.Text = this.notAvailableCount.ToString();


            this.count_total.Text = db.Books.Count().ToString();
        }

        private void loadGrid(System.Data.Entity.Core.Objects.ObjectResult<sp_FetchBooks_Search_Only_Result> data)
        {
            setAvailableOrNot();
            int totalValueOnPagination = (this.pageNumber * this.maxSearchContent) > this.total ? this.total : (this.pageNumber * this.maxSearchContent);
            count_pagination.Text = $"{(this.pageNumber * this.maxSearchContent) - this.maxSearchContent + 1} - {totalValueOnPagination} of {this.total}";

            int maxPages = (int)Math.Ceiling((decimal)this.total / this.maxSearchContent);

            if (maxPages > 1 && this.pageNumber < maxPages)
            {
                btn_next.Enabled = true;
            }
            else
            {
                btn_next.Enabled = false;
            }

            dg_book_list.DataSource = data;

            dg_book_list.Columns[0].Visible = false;
            dg_book_list.Columns[6].Visible = false;
            dg_book_list.Columns[7].Visible = false;
            dg_book_list.Columns[9].Visible = false;
            dg_book_list.Columns[10].Visible = false;

            dg_book_list.Columns[1].HeaderText = "Title";
            dg_book_list.Columns[1].Width = 250;

            dg_book_list.Columns[2].HeaderText = "Description";
            dg_book_list.Columns[2].Width = 350;
            dg_book_list.Columns[3].Width = 200;
            dg_book_list.Columns[0].Visible = false;
            dg_book_list.Columns[4].HeaderText = "Published Year";
            dg_book_list.Columns[8].HeaderText = "Return Date";

            dg_book_list.CellFormatting += Dg_book_list_CellFormatting;

        }

        private void Dg_book_list_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg_book_list.Columns[e.ColumnIndex].HeaderText == "Return Date")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value is DateTime returnDate)
                    {
                        e.Value = returnDate.ToString("yyyy-MM-dd");
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void LoadBooks()
        {
            try
            {
                type_selection.SelectedValue = 1;
                this.searchType = 1;
                this.pageNumber = 1;
                this.searchText = null;
                search_text.Text = null;
                int count = db.sp_FetchBooks_Simple(this.searchType, this.searchText).Count();
                this.total = count;
                var db_books = db.sp_FetchBooks_Search_Only(this.pageNumber, this.searchType, this.maxSearchContent, this.searchText);




                loadGrid(db_books);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());

                WarningPopUp warning = new WarningPopUp("Issue Loading Books", "Issue loading Books", "There seems to be an issue loading books.");
                warning.ShowDialog();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_book_list_Click(object sender, EventArgs e)
        {
            try
            {
                clear_book_info();

                var id = dg_book_list.SelectedRows[0].Cells["Book_id"].Value;
                Console.WriteLine(id);

                if (id != null)
                {
                    this.selectedBook = db.Books.FirstOrDefault(b => b.Book_id == (int)id);
                    if (selectedBook != null)
                    {



                        info_author.Text = selectedBook.Author;
                        info_available.Checked = selectedBook.Available;
                        info_decsription.Text = selectedBook.Description;
                        info_year.Text = selectedBook.PublishedYear.ToString();
                        info_title.Text = selectedBook.Title;

                        if (systemUser.Type == "STAFF" || systemUser.Type == "ADMIN")
                        {
                            btn_edit.Enabled = true;
                            btn_edit.Visible = true;

                            btn_delete.Enabled = true;
                            btn_delete.Visible = true;

                            btn_new_book.Enabled = true;
                            btn_new_book.Visible = true;
                        }

                        btn_borrow.Enabled = selectedBook.Available;
                        btn_borrow.Visible = selectedBook.Available;

                        btn_clear.Enabled = true;
                        btn_clear.Visible = true;
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("SelectedBook: ", err);
            }

        }

        private void clear_book_info()
        {
            this.selectedBook = null;
            this.editMode = false;

            if (systemUser.Type == "ADMIN" || systemUser.Type == "STAFF")
            {
                this.btn_new_book.Visible = true;
                this.btn_new_book.Enabled = true;
            }

            this.newBookMode = false;

            info_author.ReadOnly = true;
            info_decsription.ReadOnly = true;
            info_year.ReadOnly = true;
            info_title.ReadOnly = true;

            this.btn_delete.Text = "Delete";
            this.btn_edit.Text = "Edit";

            info_author.Text = null;
            info_available.Checked = false;
            info_decsription.Text = null;
            info_year.Text = null;
            info_title.Text = null;

            btn_edit.Enabled = false;
            btn_edit.Visible = false;

            btn_delete.Enabled = false;
            btn_delete.Visible = false;

            btn_borrow.Enabled = false;
            btn_borrow.Visible = false;

            btn_clear.Enabled = false;
            btn_clear.Visible = false;
        }

        private void next_Click(object sender, EventArgs e)
        {
            int maxPages = (int)Math.Ceiling((decimal)this.total / this.maxSearchContent);
            if (this.pageNumber + 1 <= maxPages)
            {
                btn_prev.Enabled = true;
                this.pageNumber++;
                if (this.pageNumber >= maxPages)
                {
                    btn_next.Enabled = false;
                }


                var db_books = db.sp_FetchBooks_Search_Only(this.pageNumber, this.searchType, this.maxSearchContent, this.searchText);
                loadGrid(db_books);
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {

            if (this.pageNumber - 1 >= 1)
            {
                this.pageNumber--;
                if (this.pageNumber == 1)
                {
                    btn_prev.Enabled = false;
                }

                var db_books = db.sp_FetchBooks_Search_Only(this.pageNumber, this.searchType, this.maxSearchContent, this.searchText);
                loadGrid(db_books);
            }
        }

        private void search()
        {
            this.searchText = search_text.Text;

            this.pageNumber = 1;
            int count = db.sp_FetchBooks_Simple(this.searchType, this.searchText).Count();
            this.total = count;
            var db_books = db.sp_FetchBooks_Search_Only(this.pageNumber, this.searchType, this.maxSearchContent, this.searchText);

            loadGrid(db_books);

        }

        private void reset()
        {
            LoadBooks();
        }

        private void search_text_TextChanged(object sender, EventArgs e)
        {
            if (search_text.Text.Length >= 2)
            {
                btn_search.Enabled = true;
            }
            else
            {
                btn_search.Enabled = false;
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void type_selection_SelectedValueChanged_1(object sender, EventArgs e)
        {
            this.searchType = Convert.ToInt32(type_selection.SelectedValue);

            this.pageNumber = 1;
            int count = db.sp_FetchBooks_Simple(this.searchType, this.searchText).Count();
            this.total = count;
            var db_books = db.sp_FetchBooks_Search_Only(this.pageNumber, this.searchType, this.maxSearchContent, this.searchText);

            loadGrid(db_books);
        }

        private void btn_borrow_Click(object sender, EventArgs e)
        {
            using (ConfirmBorrow confirmBorrow = (new ConfirmBorrow(this.systemUser.User_id, this.selectedBook.Book_id, "Borrow " + this.selectedBook.Title, "Borrow " + this.selectedBook.Title, "This is a demo decsription for the modal")))
            {
                if (confirmBorrow.ShowDialog() == DialogResult.OK)
                {
                    string userInput = confirmBorrow.BorrowDays; // Get user input
                    LoadBooks();
                    clear_book_info();
                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clear_book_info();
        }

        private void saveClick()
        {
            try
            {
                if (this.editMode && this.selectedBook != null || this.newBookMode)
                {
                    string newTitle = info_title.Text;
                    string newAuthor = info_author.Text;
                    string newDescription = info_decsription.Text;
                    string newYear = info_year.Text;

                    string TitleBarTitle = this.newBookMode ? "New Book" : "Book Update";
                    string MessageTitle = this.newBookMode ? "New" : "Update";

                    if (string.IsNullOrEmpty(newTitle) || string.IsNullOrEmpty(newAuthor) || string.IsNullOrEmpty(newDescription) || string.IsNullOrEmpty(newYear) || newYear.Length != 4)
                    {
                        using (WarningPopUp success = (new WarningPopUp(TitleBarTitle, $"{MessageTitle} Error", $"There seems to be an issue please ensure all fields are filled out properly!")))
                        {
                            success.ShowDialog();
                        }
                    }
                    else
                    {
                        int theBookId = this.newBookMode ? 0 : Convert.ToInt32(selectedBook.Book_id);
                        Book book = null;

                        if (!this.newBookMode)
                        {
                            book = db.Books.FirstOrDefault(b => b.Book_id == theBookId);
                        }

                        if (!this.newBookMode && book == null)
                        {
                            using (WarningPopUp success = (new WarningPopUp(TitleBarTitle, $"{MessageTitle} Error", $"There seems to be an issue please contact support!")))
                            {
                                if (success.ShowDialog() == DialogResult.OK)
                                {
                                    return;
                                }
                            }
                        }
                        else
                        {
                            int intYear = Convert.ToInt32(newYear);

                            if (this.newBookMode)
                            {
                                book = new Book
                                {
                                    Title = newTitle,
                                    Author = newAuthor,
                                    Description = newDescription,
                                    PublishedYear = intYear,
                                    Available = true
                                };

                                db.Books.Add(book);

                            }
                            else
                            {
                                book.Title = newTitle;
                                book.Author = newAuthor;
                                book.Description = newDescription;

                                book.PublishedYear = intYear;
                            }

                            db.SaveChanges();

                            this.selectedBook = book;

                            if (this.newBookMode)
                            {
                                this.info_available.Checked = true;
                                this.btn_clear.Visible = true;
                                this.btn_clear.Enabled = true;
                            }

                            string MessageEnd = this.newBookMode ? "added" : "updated";
                            using (WarningPopUp success = (new WarningPopUp(TitleBarTitle, $"Book Successfully {MessageEnd}", $"{newTitle} by {newAuthor} was successfully {MessageEnd}!")))
                            {
                                if (success.ShowDialog() == DialogResult.OK)
                                {
                                    info_author.ReadOnly = true;
                                    info_decsription.ReadOnly = true;
                                    info_year.ReadOnly = true;
                                    info_title.ReadOnly = true;

                                    this.editMode = false;
                                    this.btn_new_book.Visible = true;
                                    this.btn_borrow.Visible = true;
                                    this.btn_delete.Text = "Delete";
                                    this.btn_edit.Text = "Edit";
                                    this.newBookMode = false;

                                   

                                    LoadBooks();
                                }
                            }
                        }
                    }



                }
                else
                {
                    info_author.ReadOnly = false;
                    info_decsription.ReadOnly = false;
                    info_year.ReadOnly = false;
                    info_title.ReadOnly = false;


                    this.editMode = true;
                    this.btn_new_book.Visible = true;
                    this.btn_new_book.Enabled = false;
                    this.btn_borrow.Visible = false;
                    this.btn_delete.Text = "Cancel";
                    this.btn_edit.Text = "Save";
                }
            }
            catch (Exception)
            {
                using(WarningPopUp warning = (new WarningPopUp("System Error", "System Error", "There is a system error, please contact support")))
                {
                    warning.ShowDialog();
                }
            }
      
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            saveClick();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.editMode || this.newBookMode)
                {
                    info_author.Text = this.newBookMode ? null :  selectedBook.Author;
                    info_decsription.Text = this.newBookMode ? null :  selectedBook.Description;
                    info_year.Text = this.newBookMode ? null :  selectedBook.PublishedYear.ToString();
                    info_title.Text = this.newBookMode ? null :  selectedBook.Title;

                    info_author.ReadOnly = true;
                    info_decsription.ReadOnly = true;
                    info_year.ReadOnly = true;
                    info_title.ReadOnly = true;

                    this.btn_borrow.Visible = this.newBookMode ? false :true;

                    if (this.newBookMode)
                    {
                        this.btn_edit.Visible = false;
                        this.btn_delete.Visible = false;
                        this.btn_clear.Visible = false;
                    }

                    this.editMode = false;
                    this.newBookMode = false;
                    this.btn_new_book.Visible = true;
                    this.btn_new_book.Enabled = true;

                    this.btn_delete.Text = "Delete";
                    this.btn_edit.Text = "Edit";                   
                }
                else
                {
                    using (ConfirmModal confirmDelete = (new ConfirmModal("Delete", "Delete Book", $"You are about to delete {selectedBook.Title} by {selectedBook.Author}. This action cannot be undone! Are you sure you want to continue with this action?")))
                    {
                        if (confirmDelete.ShowDialog() == DialogResult.OK)
                        {
                            db.Books.Remove(selectedBook);
                            db.SaveChanges();
                            clear_book_info();
                            LoadBooks();
                        };
                    }
                }
            }
            catch (Exception)
            {
                using (WarningPopUp confirmDelete = (new WarningPopUp("System Error", "Internal System Error", "There seems to be a system error please contact support.")))
                {
                    confirmDelete.ShowDialog();
                }
            }
        }

        private void info_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block input
            }
        }

        private void btn_new_book_Click(object sender, EventArgs e)
        {
            info_author.ReadOnly = false;
            info_decsription.ReadOnly = false;
            info_year.ReadOnly = false;
            info_title.ReadOnly = false;

            info_author.Text = null;
            info_decsription.Text = null;
            info_year.Text = null;
            info_title.Text = null;


            this.selectedBook = null;
            this.btn_delete.Visible = true;
            this.btn_edit.Visible = true;
            this.btn_delete.Enabled = true;
            this.btn_edit.Enabled = true;
            this.btn_delete.Text = "Cancel";
            
            this.btn_borrow.Visible = false;

            saveClick();
            this.btn_edit.Text = "Save New";
            this.newBookMode = true;
            this.btn_clear.Visible = false;
        }
    }



}
