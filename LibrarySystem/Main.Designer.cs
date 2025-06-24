namespace LibrarySystem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.main_menu = new System.Windows.Forms.MenuStrip();
            this.mbtn_user_name = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtb_user_account = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_view_all_books = new System.Windows.Forms.ToolStripMenuItem();
            this.myRentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_overdue = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_user_manage = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_view_all_users = new System.Windows.Forms.ToolStripMenuItem();
            this.mbtn_add_user = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.info_panel = new System.Windows.Forms.Panel();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loadingPanel = new System.Windows.Forms.PictureBox();
            this.login_panel = new System.Windows.Forms.Panel();
            this.main_menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.info_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPanel)).BeginInit();
            this.login_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_menu
            // 
            this.main_menu.BackColor = System.Drawing.SystemColors.Window;
            this.main_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtn_user_name,
            this.booksToolStripMenuItem,
            this.mbtn_user_manage});
            this.main_menu.Location = new System.Drawing.Point(0, 0);
            this.main_menu.Name = "main_menu";
            this.main_menu.Size = new System.Drawing.Size(844, 24);
            this.main_menu.TabIndex = 1;
            this.main_menu.Text = "menuStrip1";
            // 
            // mbtn_user_name
            // 
            this.mbtn_user_name.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtb_user_account,
            this.mbtn_logout});
            this.mbtn_user_name.Name = "mbtn_user_name";
            this.mbtn_user_name.Size = new System.Drawing.Size(72, 20);
            this.mbtn_user_name.Text = "{{-USER-}}";
            // 
            // mbtb_user_account
            // 
            this.mbtb_user_account.Name = "mbtb_user_account";
            this.mbtb_user_account.Size = new System.Drawing.Size(145, 22);
            this.mbtb_user_account.Text = "User Account";
            this.mbtb_user_account.Click += new System.EventHandler(this.mbtb_user_account_Click);
            // 
            // mbtn_logout
            // 
            this.mbtn_logout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mbtn_logout.ForeColor = System.Drawing.Color.IndianRed;
            this.mbtn_logout.Name = "mbtn_logout";
            this.mbtn_logout.Size = new System.Drawing.Size(145, 22);
            this.mbtn_logout.Text = "Logout";
            this.mbtn_logout.Click += new System.EventHandler(this.mbtn_logout_Click);
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtn_view_all_books,
            this.myRentalsToolStripMenuItem,
            this.mbtn_overdue});
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.booksToolStripMenuItem.Text = "Books";
            // 
            // mbtn_view_all_books
            // 
            this.mbtn_view_all_books.Name = "mbtn_view_all_books";
            this.mbtn_view_all_books.Size = new System.Drawing.Size(132, 22);
            this.mbtn_view_all_books.Text = "View All";
            this.mbtn_view_all_books.Click += new System.EventHandler(this.mbtn_view_all_books_Click);
            // 
            // myRentalsToolStripMenuItem
            // 
            this.myRentalsToolStripMenuItem.Name = "myRentalsToolStripMenuItem";
            this.myRentalsToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.myRentalsToolStripMenuItem.Text = "My Rentals";
            this.myRentalsToolStripMenuItem.Click += new System.EventHandler(this.myRentalsToolStripMenuItem_Click);
            // 
            // mbtn_overdue
            // 
            this.mbtn_overdue.Name = "mbtn_overdue";
            this.mbtn_overdue.Size = new System.Drawing.Size(132, 22);
            this.mbtn_overdue.Text = "Overdue";
            this.mbtn_overdue.Visible = false;
            this.mbtn_overdue.Click += new System.EventHandler(this.mbtn_overdue_Click);
            // 
            // mbtn_user_manage
            // 
            this.mbtn_user_manage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mbtn_view_all_users,
            this.mbtn_add_user});
            this.mbtn_user_manage.Name = "mbtn_user_manage";
            this.mbtn_user_manage.Size = new System.Drawing.Size(116, 20);
            this.mbtn_user_manage.Text = "User Management";
            this.mbtn_user_manage.Visible = false;
            // 
            // mbtn_view_all_users
            // 
            this.mbtn_view_all_users.Name = "mbtn_view_all_users";
            this.mbtn_view_all_users.Size = new System.Drawing.Size(122, 22);
            this.mbtn_view_all_users.Text = "View All";
            this.mbtn_view_all_users.Click += new System.EventHandler(this.mbtn_view_all_users_Click);
            // 
            // mbtn_add_user
            // 
            this.mbtn_add_user.Name = "mbtn_add_user";
            this.mbtn_add_user.Size = new System.Drawing.Size(122, 22);
            this.mbtn_add_user.Text = "Add User";
            this.mbtn_add_user.Click += new System.EventHandler(this.mbtn_add_user_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.info_panel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.loadingPanel);
            this.panel1.Location = new System.Drawing.Point(277, 52);
            this.panel1.MaximumSize = new System.Drawing.Size(290, 350);
            this.panel1.MinimumSize = new System.Drawing.Size(290, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 350);
            this.panel1.TabIndex = 3;
            // 
            // info_panel
            // 
            this.info_panel.Controls.Add(this.tb_password);
            this.info_panel.Controls.Add(this.btn_login);
            this.info_panel.Controls.Add(this.label2);
            this.info_panel.Controls.Add(this.tb_email);
            this.info_panel.Controls.Add(this.label3);
            this.info_panel.Location = new System.Drawing.Point(42, 191);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(206, 149);
            this.info_panel.TabIndex = 7;
            // 
            // tb_password
            // 
            this.tb_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_password.Location = new System.Drawing.Point(19, 74);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(167, 20);
            this.tb_password.TabIndex = 4;
            this.tb_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_login.Location = new System.Drawing.Point(64, 115);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 5;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // tb_email
            // 
            this.tb_email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.tb_email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_email.Location = new System.Drawing.Point(19, 28);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(167, 20);
            this.tb_email.TabIndex = 2;
            this.tb_email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(53, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Image = ((System.Drawing.Image)(resources.GetObject("loadingPanel.Image")));
            this.loadingPanel.Location = new System.Drawing.Point(66, 184);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(163, 163);
            this.loadingPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingPanel.TabIndex = 8;
            this.loadingPanel.TabStop = false;
            // 
            // login_panel
            // 
            this.login_panel.BackColor = System.Drawing.SystemColors.Window;
            this.login_panel.Controls.Add(this.panel1);
            this.login_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_panel.Location = new System.Drawing.Point(0, 24);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(844, 487);
            this.login_panel.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.login_panel);
            this.Controls.Add(this.main_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.main_menu;
            this.MinimumSize = new System.Drawing.Size(860, 550);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JEHS - Book Rental System";
            this.main_menu.ResumeLayout(false);
            this.main_menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.info_panel.ResumeLayout(false);
            this.info_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPanel)).EndInit();
            this.login_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip main_menu;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mbtn_view_all_books;
        private System.Windows.Forms.ToolStripMenuItem mbtn_user_manage;
        private System.Windows.Forms.ToolStripMenuItem mbtn_view_all_users;
        private System.Windows.Forms.ToolStripMenuItem mbtn_add_user;
        private System.Windows.Forms.ToolStripMenuItem mbtn_user_name;
        private System.Windows.Forms.ToolStripMenuItem mbtb_user_account;
        private System.Windows.Forms.ToolStripMenuItem mbtn_logout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel login_panel;
        private System.Windows.Forms.ToolStripMenuItem myRentalsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem mbtn_overdue;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.PictureBox loadingPanel;
    }
}

