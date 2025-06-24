namespace LibrarySystem.Windows
{
    partial class CreateUser
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btn_save_new = new System.Windows.Forms.Button();
            this.info_last_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.info_first_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.info_email = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.info_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.info_password = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.info_password_retype = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_userType = new System.Windows.Forms.ComboBox();
            this.userTypeLable = new System.Windows.Forms.Label();
            this.form_title = new System.Windows.Forms.TextBox();
            this.block = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.IndianRed;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.cancelBtn.Location = new System.Drawing.Point(168, 395);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 23);
            this.cancelBtn.TabIndex = 25;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btn_save_new
            // 
            this.btn_save_new.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_save_new.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_new.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_save_new.Location = new System.Drawing.Point(56, 395);
            this.btn_save_new.Name = "btn_save_new";
            this.btn_save_new.Size = new System.Drawing.Size(94, 23);
            this.btn_save_new.TabIndex = 24;
            this.btn_save_new.Text = "Save";
            this.btn_save_new.UseVisualStyleBackColor = false;
            this.btn_save_new.Click += new System.EventHandler(this.btn_save_new_Click);
            // 
            // info_last_name
            // 
            this.info_last_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_last_name.Location = new System.Drawing.Point(56, 118);
            this.info_last_name.Name = "info_last_name";
            this.info_last_name.Size = new System.Drawing.Size(206, 20);
            this.info_last_name.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Last Name";
            // 
            // info_first_name
            // 
            this.info_first_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_first_name.Location = new System.Drawing.Point(56, 77);
            this.info_first_name.Name = "info_first_name";
            this.info_first_name.Size = new System.Drawing.Size(206, 20);
            this.info_first_name.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "First Name";
            // 
            // info_email
            // 
            this.info_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_email.Location = new System.Drawing.Point(56, 160);
            this.info_email.Name = "info_email";
            this.info_email.Size = new System.Drawing.Size(206, 20);
            this.info_email.TabIndex = 27;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(53, 144);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 26;
            this.Email.Text = "Email";
            // 
            // info_phone
            // 
            this.info_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_phone.Location = new System.Drawing.Point(56, 202);
            this.info_phone.Name = "info_phone";
            this.info_phone.Size = new System.Drawing.Size(206, 20);
            this.info_phone.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Phone";
            // 
            // info_password
            // 
            this.info_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_password.Location = new System.Drawing.Point(56, 309);
            this.info_password.Name = "info_password";
            this.info_password.PasswordChar = '*';
            this.info_password.Size = new System.Drawing.Size(206, 20);
            this.info_password.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Password";
            // 
            // info_password_retype
            // 
            this.info_password_retype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_password_retype.Location = new System.Drawing.Point(56, 349);
            this.info_password_retype.Name = "info_password_retype";
            this.info_password_retype.PasswordChar = '*';
            this.info_password_retype.Size = new System.Drawing.Size(206, 20);
            this.info_password_retype.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Re-Type Password";
            // 
            // combo_userType
            // 
            this.combo_userType.FormattingEnabled = true;
            this.combo_userType.Location = new System.Drawing.Point(56, 254);
            this.combo_userType.Name = "combo_userType";
            this.combo_userType.Size = new System.Drawing.Size(121, 21);
            this.combo_userType.TabIndex = 34;
            // 
            // userTypeLable
            // 
            this.userTypeLable.AutoSize = true;
            this.userTypeLable.Location = new System.Drawing.Point(53, 238);
            this.userTypeLable.Name = "userTypeLable";
            this.userTypeLable.Size = new System.Drawing.Size(56, 13);
            this.userTypeLable.TabIndex = 35;
            this.userTypeLable.Text = "User Type";
            // 
            // form_title
            // 
            this.form_title.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.form_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.form_title.Location = new System.Drawing.Point(56, 32);
            this.form_title.Name = "form_title";
            this.form_title.Size = new System.Drawing.Size(206, 19);
            this.form_title.TabIndex = 36;
            this.form_title.Text = "Add New User";
            this.form_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // block
            // 
            this.block.AutoSize = true;
            this.block.Location = new System.Drawing.Point(209, 257);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(53, 17);
            this.block.TabIndex = 37;
            this.block.Text = "Block";
            this.block.UseVisualStyleBackColor = true;
            this.block.Visible = false;
            // 
            // CreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(314, 451);
            this.Controls.Add(this.block);
            this.Controls.Add(this.form_title);
            this.Controls.Add(this.userTypeLable);
            this.Controls.Add(this.combo_userType);
            this.Controls.Add(this.info_password_retype);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.info_password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.info_phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.info_email);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.btn_save_new);
            this.Controls.Add(this.info_last_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.info_first_name);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 490);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 490);
            this.Name = "CreateUser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btn_save_new;
        private System.Windows.Forms.TextBox info_last_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox info_first_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox info_email;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox info_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox info_password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox info_password_retype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_userType;
        private System.Windows.Forms.Label userTypeLable;
        private System.Windows.Forms.TextBox form_title;
        private System.Windows.Forms.CheckBox block;
    }
}