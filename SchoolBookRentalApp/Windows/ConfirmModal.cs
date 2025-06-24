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
    public partial class ConfirmModal : Form
    {
        public ConfirmModal(string header, string title, string description)
        {
            InitializeComponent();

            this.Text = header;
            this.modal_title.Text = title;
            this.modal_info.Text = description;
        }

        private void ok()
        {
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
            ok();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            ok();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cancel();
        }

    }
}
