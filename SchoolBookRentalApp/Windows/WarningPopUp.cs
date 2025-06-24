using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.Windows
{
    public partial class WarningPopUp : Form
    {
        public WarningPopUp(string popUpTitle,string msgTitle, string msg)
        {
            InitializeComponent();

            this.Text = popUpTitle;
            title_box.Text = msgTitle;
            msg_box.Text = msg;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Close dialog with OK result
            this.Close();
        }

    }
}
