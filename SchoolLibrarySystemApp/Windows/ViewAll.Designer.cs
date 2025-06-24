namespace LibrarySystem.Windows
{
    partial class ViewAll
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
            this.search_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dg_book_list = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_new_book = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_borrow = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.info_available = new System.Windows.Forms.CheckBox();
            this.info_year = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.info_decsription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.info_author = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.info_title = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_prev = new System.Windows.Forms.Button();
            this.count_pagination = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.count_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.count_available = new System.Windows.Forms.Label();
            this.count_not_available = new System.Windows.Forms.Label();
            this.type_selection = new System.Windows.Forms.ComboBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_book_list)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // search_text
            // 
            this.search_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_text.Location = new System.Drawing.Point(18, 26);
            this.search_text.Name = "search_text";
            this.search_text.Size = new System.Drawing.Size(191, 20);
            this.search_text.TabIndex = 0;
            this.search_text.TextChanged += new System.EventHandler(this.search_text_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book Search";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 464);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(844, 377);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dg_book_list);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(235, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(609, 377);
            this.panel5.TabIndex = 1;
            // 
            // dg_book_list
            // 
            this.dg_book_list.AllowUserToAddRows = false;
            this.dg_book_list.AllowUserToDeleteRows = false;
            this.dg_book_list.AllowUserToResizeRows = false;
            this.dg_book_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_book_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_book_list.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg_book_list.Location = new System.Drawing.Point(0, 0);
            this.dg_book_list.MultiSelect = false;
            this.dg_book_list.Name = "dg_book_list";
            this.dg_book_list.ReadOnly = true;
            this.dg_book_list.ShowEditingIcon = false;
            this.dg_book_list.Size = new System.Drawing.Size(609, 377);
            this.dg_book_list.TabIndex = 0;
            this.dg_book_list.Click += new System.EventHandler(this.dg_book_list_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_new_book);
            this.panel4.Controls.Add(this.btn_clear);
            this.panel4.Controls.Add(this.btn_borrow);
            this.panel4.Controls.Add(this.btn_delete);
            this.panel4.Controls.Add(this.btn_edit);
            this.panel4.Controls.Add(this.info_available);
            this.panel4.Controls.Add(this.info_year);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.info_decsription);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.info_author);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.info_title);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(235, 377);
            this.panel4.TabIndex = 0;
            // 
            // btn_new_book
            // 
            this.btn_new_book.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btn_new_book.Enabled = false;
            this.btn_new_book.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new_book.Location = new System.Drawing.Point(18, 10);
            this.btn_new_book.Name = "btn_new_book";
            this.btn_new_book.Size = new System.Drawing.Size(75, 23);
            this.btn_new_book.TabIndex = 26;
            this.btn_new_book.Text = "New Book";
            this.btn_new_book.UseVisualStyleBackColor = false;
            this.btn_new_book.Visible = false;
            this.btn_new_book.Click += new System.EventHandler(this.btn_new_book_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.SystemColors.Info;
            this.btn_clear.Enabled = false;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(134, 10);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 25;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Visible = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_borrow
            // 
            this.btn_borrow.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_borrow.Enabled = false;
            this.btn_borrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_borrow.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_borrow.Location = new System.Drawing.Point(18, 319);
            this.btn_borrow.Name = "btn_borrow";
            this.btn_borrow.Size = new System.Drawing.Size(191, 28);
            this.btn_borrow.TabIndex = 24;
            this.btn_borrow.Text = "Borrow";
            this.btn_borrow.UseVisualStyleBackColor = false;
            this.btn_borrow.Visible = false;
            this.btn_borrow.Click += new System.EventHandler(this.btn_borrow_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.IndianRed;
            this.btn_delete.Enabled = false;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_delete.Location = new System.Drawing.Point(118, 291);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(91, 23);
            this.btn_delete.TabIndex = 21;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Visible = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.SystemColors.Info;
            this.btn_edit.Enabled = false;
            this.btn_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.Location = new System.Drawing.Point(18, 291);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(94, 23);
            this.btn_edit.TabIndex = 20;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Visible = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // info_available
            // 
            this.info_available.AutoSize = true;
            this.info_available.Enabled = false;
            this.info_available.Location = new System.Drawing.Point(134, 250);
            this.info_available.Name = "info_available";
            this.info_available.Size = new System.Drawing.Size(69, 17);
            this.info_available.TabIndex = 19;
            this.info_available.Text = "Available";
            this.info_available.UseVisualStyleBackColor = true;
            // 
            // info_year
            // 
            this.info_year.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_year.Location = new System.Drawing.Point(18, 247);
            this.info_year.MaxLength = 4;
            this.info_year.Name = "info_year";
            this.info_year.ReadOnly = true;
            this.info_year.Size = new System.Drawing.Size(84, 20);
            this.info_year.TabIndex = 16;
            this.info_year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.info_year_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(15, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Year";
            // 
            // info_decsription
            // 
            this.info_decsription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_decsription.Location = new System.Drawing.Point(18, 136);
            this.info_decsription.Multiline = true;
            this.info_decsription.Name = "info_decsription";
            this.info_decsription.ReadOnly = true;
            this.info_decsription.Size = new System.Drawing.Size(191, 89);
            this.info_decsription.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(15, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "Description";
            // 
            // info_author
            // 
            this.info_author.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_author.Location = new System.Drawing.Point(18, 96);
            this.info_author.Name = "info_author";
            this.info_author.ReadOnly = true;
            this.info_author.Size = new System.Drawing.Size(191, 20);
            this.info_author.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(15, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Author";
            // 
            // info_title
            // 
            this.info_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.info_title.Location = new System.Drawing.Point(18, 56);
            this.info_title.Name = "info_title";
            this.info_title.ReadOnly = true;
            this.info_title.Size = new System.Drawing.Size(191, 20);
            this.info_title.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(15, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Title";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.type_selection);
            this.panel2.Controls.Add(this.close_btn);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.btn_reset);
            this.panel2.Controls.Add(this.search_text);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(844, 87);
            this.panel2.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel7.Controls.Add(this.btn_next);
            this.panel7.Controls.Add(this.btn_prev);
            this.panel7.Controls.Add(this.count_pagination);
            this.panel7.Location = new System.Drawing.Point(426, 18);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 53);
            this.panel7.TabIndex = 30;
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_next.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_next.Enabled = false;
            this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_next.Location = new System.Drawing.Point(101, 20);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(91, 23);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.next_Click);
            // 
            // btn_prev
            // 
            this.btn_prev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_prev.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_prev.Enabled = false;
            this.btn_prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prev.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_prev.Location = new System.Drawing.Point(4, 20);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(91, 23);
            this.btn_prev.TabIndex = 2;
            this.btn_prev.Text = "Previous";
            this.btn_prev.UseVisualStyleBackColor = false;
            this.btn_prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // count_pagination
            // 
            this.count_pagination.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.count_pagination.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.count_pagination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_pagination.Location = new System.Drawing.Point(4, 6);
            this.count_pagination.Name = "count_pagination";
            this.count_pagination.Size = new System.Drawing.Size(188, 13);
            this.count_pagination.TabIndex = 13;
            this.count_pagination.Text = "50/3000";
            this.count_pagination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.count_total);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.count_available);
            this.panel6.Controls.Add(this.count_not_available);
            this.panel6.Location = new System.Drawing.Point(630, 15);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(205, 56);
            this.panel6.TabIndex = 29;
            // 
            // count_total
            // 
            this.count_total.AutoSize = true;
            this.count_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_total.Location = new System.Drawing.Point(12, 32);
            this.count_total.Name = "count_total";
            this.count_total.Size = new System.Drawing.Size(49, 13);
            this.count_total.TabIndex = 8;
            this.count_total.Text = "200000";
            this.count_total.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total Count";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Available";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Out";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // count_available
            // 
            this.count_available.AutoSize = true;
            this.count_available.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_available.Location = new System.Drawing.Point(79, 32);
            this.count_available.Name = "count_available";
            this.count_available.Size = new System.Drawing.Size(49, 13);
            this.count_available.TabIndex = 9;
            this.count_available.Text = "200000";
            this.count_available.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // count_not_available
            // 
            this.count_not_available.AutoSize = true;
            this.count_not_available.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count_not_available.Location = new System.Drawing.Point(146, 32);
            this.count_not_available.Name = "count_not_available";
            this.count_not_available.Size = new System.Drawing.Size(49, 13);
            this.count_not_available.TabIndex = 10;
            this.count_not_available.Text = "200000";
            this.count_not_available.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // type_selection
            // 
            this.type_selection.FormattingEnabled = true;
            this.type_selection.Location = new System.Drawing.Point(18, 52);
            this.type_selection.Name = "type_selection";
            this.type_selection.Size = new System.Drawing.Size(191, 21);
            this.type_selection.TabIndex = 28;
            this.type_selection.SelectedValueChanged += new System.EventHandler(this.type_selection_SelectedValueChanged_1);
            // 
            // close_btn
            // 
            this.close_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_btn.BackColor = System.Drawing.Color.IndianRed;
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.ForeColor = System.Drawing.SystemColors.Window;
            this.close_btn.Location = new System.Drawing.Point(376, 14);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(25, 23);
            this.close_btn.TabIndex = 11;
            this.close_btn.Text = "X";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Visible = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Info;
            this.btn_search.Enabled = false;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(215, 24);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(62, 22);
            this.btn_search.TabIndex = 27;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.SystemColors.Info;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(215, 51);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(62, 22);
            this.btn_reset.TabIndex = 26;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // ViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 464);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 480);
            this.Name = "ViewAll";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Books";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_book_list)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox search_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dg_book_list;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox info_decsription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox info_author;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox info_title;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label count_not_available;
        private System.Windows.Forms.Label count_available;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.CheckBox info_available;
        private System.Windows.Forms.TextBox info_year;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_borrow;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label count_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox count_pagination;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox type_selection;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_new_book;
    }
}