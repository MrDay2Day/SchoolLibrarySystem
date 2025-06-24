using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.Utils;

namespace LibrarySystem.Windows
{
    public partial class Overdue : Form
    {
        private User systemUser;
        public Overdue(User user)
        {
            InitializeComponent();
            this.systemUser = user;
        }

        private void btn_save_new_Click(object sender, EventArgs e)
        {
            using (Payment paymentForm = (new Payment(12345.98)))
            {
                paymentForm.ShowDialog();
            }
        }
    }
}
