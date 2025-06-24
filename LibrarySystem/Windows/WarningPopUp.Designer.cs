namespace LibrarySystem.Windows
{
    partial class WarningPopUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.msg_box = new System.Windows.Forms.TextBox();
            this.title_box = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.msg_box);
            this.panel1.Controls.Add(this.title_box);
            this.panel1.Controls.Add(this.btn_ok);
            this.panel1.Location = new System.Drawing.Point(9, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 210);
            this.panel1.TabIndex = 0;
            // 
            // msg_box
            // 
            this.msg_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msg_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.msg_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg_box.Location = new System.Drawing.Point(20, 79);
            this.msg_box.Multiline = true;
            this.msg_box.Name = "msg_box";
            this.msg_box.Size = new System.Drawing.Size(236, 86);
            this.msg_box.TabIndex = 4;
            this.msg_box.Text = "This is the message body.";
            this.msg_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // title_box
            // 
            this.title_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.title_box.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.title_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_box.Location = new System.Drawing.Point(20, 20);
            this.title_box.Multiline = true;
            this.title_box.Name = "title_box";
            this.title_box.Size = new System.Drawing.Size(236, 53);
            this.title_box.TabIndex = 3;
            this.title_box.Text = "MESSAGE TITLE";
            this.title_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.SystemColors.Info;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(74, 171);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(126, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "Close";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // WarningPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(294, 241);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 280);
            this.Name = "WarningPopUp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WarningPopUp";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox msg_box;
        private System.Windows.Forms.TextBox title_box;
        private System.Windows.Forms.Button btn_ok;
    }
}