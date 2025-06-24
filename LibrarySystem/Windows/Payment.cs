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
    public partial class Payment : Form
    {
        double amount_due;
        string errMsg;
        public Payment(double _amount)
        {
            InitializeComponent();
            this.amount_due = _amount;
            lb_total.Text = $"${this.amount_due.ToString()}";

            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.AddRange(new string[] { "Cash", "Card" });
            comboBox1.SelectedIndex = 1; // Default to Cash
        }

        private bool ValidateCardFields()
        {
            errMsg = "";

            if (!checkBox1.Checked)
            {
                errMsg = errMsg + "Please agree to the terms. ";
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errMsg = errMsg + "Please enter the name on the card. ";
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, @"^\d+$")) //only digits
            {
                errMsg = errMsg + "Please enter a valid card number. ";
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, @"^\d{2}$")) //only 2 digits
            {
                errMsg = errMsg + "Please enter a valid month (MM). ";
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, @"^\d{4}$")) //only 4 digits
            {
                errMsg = errMsg + "Please enter a valid year (YYYY). ";
            }

            if (string.IsNullOrWhiteSpace(textBox5.Text) || !System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, @"^\d{3}$")) //only 3 digits
            {
                errMsg = errMsg + "Please enter a valid CVV (###). ";
            }

            if (errMsg.Length > 0) { return false;  }

            return true; // All fields are valid
        }

        private void btn_save_new_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Card")
            {
                if (!ValidateCardFields())
                {
                    MessageBox.Show(errMsg);
                    errMsg = null;
                    return; // Validation failed
                }
                else
                {
                    success();
                }


            }
            else
            {
                success();
            }


        }

        private void success()
        {
            using (WarningPopUp success = (new WarningPopUp("Payment Successfull", $"{comboBox1.SelectedItem.ToString()} payment successful!", $"Your payment of ${amount_due} was successfull!")))
            {
                if (success.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Card")
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }
    }
}
