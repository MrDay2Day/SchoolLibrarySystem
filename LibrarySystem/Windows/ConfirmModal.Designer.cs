namespace LibrarySystem.Windows
{
    partial class ConfirmModal
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.modal_info = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.modal_title = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 281);
            this.panel1.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.Controls.Add(this.btn_confirm);
            this.panel4.Controls.Add(this.btn_cancel);
            this.panel4.Location = new System.Drawing.Point(11, 231);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 40);
            this.panel4.TabIndex = 3;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_confirm.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_confirm.ForeColor = System.Drawing.Color.Black;
            this.btn_confirm.Location = new System.Drawing.Point(21, 6);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(99, 23);
            this.btn_confirm.TabIndex = 2;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = false;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_cancel.BackColor = System.Drawing.Color.MistyRose;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(139, 6);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(99, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.modal_info);
            this.panel3.Location = new System.Drawing.Point(11, 101);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 124);
            this.panel3.TabIndex = 2;
            // 
            // modal_info
            // 
            this.modal_info.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modal_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modal_info.Location = new System.Drawing.Point(18, 3);
            this.modal_info.MinimumSize = new System.Drawing.Size(217, 0);
            this.modal_info.Multiline = true;
            this.modal_info.Name = "modal_info";
            this.modal_info.Size = new System.Drawing.Size(217, 118);
            this.modal_info.TabIndex = 1;
            this.modal_info.Text = "Information explaining what is going on.";
            this.modal_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.modal_title);
            this.panel2.Location = new System.Drawing.Point(11, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 92);
            this.panel2.TabIndex = 0;
            // 
            // modal_title
            // 
            this.modal_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modal_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modal_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modal_title.Location = new System.Drawing.Point(18, 6);
            this.modal_title.MinimumSize = new System.Drawing.Size(217, 0);
            this.modal_title.Multiline = true;
            this.modal_title.Name = "modal_title";
            this.modal_title.Size = new System.Drawing.Size(217, 78);
            this.modal_title.TabIndex = 0;
            this.modal_title.Text = "Title Goes Here";
            this.modal_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfirmModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(294, 296);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 335);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 335);
            this.Name = "ConfirmModal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfirmModal";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox modal_info;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox modal_title;
    }
}