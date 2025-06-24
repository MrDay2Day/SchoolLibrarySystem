using System;
using System.Windows.Forms;

namespace LibrarySystem.Windows
{
    public partial class ConfirmBorrow : Form
    {
        private Library_SystemEntities db;
        public string BorrowDays { get; private set; }
        private int userId;
        private int bookId;
        public ConfirmBorrow(int _userId, int _bookId, string header, string title, string description)
        {

            InitializeComponent();

            db = new Library_SystemEntities();

            this.Text = header;
            this.modal_title.Text = title;
            this.modal_info.Text = description;
            this.userId = _userId;
            this.bookId = _bookId;


        }

        private void ok()
        {
            BorrowDays = borrow_days.Text;
            this.DialogResult = DialogResult.OK; // Close dialog with OK result
            this.Close();
        }

        private void cancel()
        {
            this.DialogResult = DialogResult.Cancel; // Close dialog with Cancel result
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(borrow_days.Text) > 14)
                {
                    using (WarningPopUp warning = (
                       new WarningPopUp(
                           "Borrow Days Error",
                           "Borrow Days Excceeded",
                           "You can only borrow for a minimum of 1 day or a maximum of 14.")))
                        {
                            if (warning.ShowDialog() == DialogResult.OK)
                            {
                                ok();
                            }
                        }

                    return;
                }
                Console.WriteLine($"{this.bookId}, {this.userId}, {Convert.ToInt32(borrow_days.Text)}");
                db.sp_BorrowBook(this.bookId, this.userId, Convert.ToInt32(borrow_days.Text));
                db.SaveChanges();

                using (WarningPopUp warning = (
                    new WarningPopUp(
                        "Successfull Borrow",
                        "Borrow Registered",
                        "This borrow has been successfully registered")))
                {
                    if (warning.ShowDialog() == DialogResult.OK)
                    {
                        ok();
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                using (WarningPopUp warning = (
                    new WarningPopUp(
                        "System Issue",
                        "Issue registering this borrow",
                        "There seems to be an issue with registereing this borrow. Please ensure you have no outstanding fees. If this problem continues please contact support.")))
                {
                    warning.ShowDialog();
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void borrow_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys (Backspace, Delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block input
            }
        }
    }
}
