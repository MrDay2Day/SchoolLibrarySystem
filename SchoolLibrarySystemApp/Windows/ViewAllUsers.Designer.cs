namespace LibrarySystem.Windows
{
    partial class ViewAllUsers
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.count = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_prev = new System.Windows.Forms.Button();
            this.count_pagination = new System.Windows.Forms.TextBox();
            this.type_selection = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.search_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.usersdgv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersdgv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.type_selection);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.btn_reset);
            this.panel1.Controls.Add(this.search_text);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 86);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.count);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(588, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(84, 56);
            this.panel6.TabIndex = 30;
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.count.Location = new System.Drawing.Point(12, 32);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(49, 13);
            this.count.TabIndex = 8;
            this.count.Text = "200000";
            this.count.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel7.Controls.Add(this.btn_next);
            this.panel7.Controls.Add(this.btn_prev);
            this.panel7.Controls.Add(this.count_pagination);
            this.panel7.Location = new System.Drawing.Point(333, 20);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(198, 53);
            this.panel7.TabIndex = 34;
            // 
            // btn_next
            // 
            this.btn_next.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_next.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_next.Location = new System.Drawing.Point(101, 20);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(91, 23);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_prev
            // 
            this.btn_prev.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_prev.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_prev.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_prev.Location = new System.Drawing.Point(4, 20);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(91, 23);
            this.btn_prev.TabIndex = 2;
            this.btn_prev.Text = "Previous";
            this.btn_prev.UseVisualStyleBackColor = false;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
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
            // type_selection
            // 
            this.type_selection.FormattingEnabled = true;
            this.type_selection.Location = new System.Drawing.Point(15, 52);
            this.type_selection.Name = "type_selection";
            this.type_selection.Size = new System.Drawing.Size(191, 21);
            this.type_selection.TabIndex = 33;
            this.type_selection.SelectedIndexChanged += new System.EventHandler(this.type_selection_SelectedIndexChanged);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Info;
            this.btn_search.Enabled = false;
            this.btn_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(212, 24);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(62, 22);
            this.btn_search.TabIndex = 32;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.SystemColors.Info;
            this.btn_reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(212, 51);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(62, 22);
            this.btn_reset.TabIndex = 31;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // search_text
            // 
            this.search_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_text.Location = new System.Drawing.Point(15, 26);
            this.search_text.Name = "search_text";
            this.search_text.Size = new System.Drawing.Size(191, 20);
            this.search_text.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "User Search";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.usersdgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 364);
            this.panel2.TabIndex = 1;
            // 
            // usersdgv
            // 
            this.usersdgv.AllowUserToAddRows = false;
            this.usersdgv.AllowUserToDeleteRows = false;
            this.usersdgv.AllowUserToResizeRows = false;
            this.usersdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersdgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.usersdgv.Location = new System.Drawing.Point(0, 0);
            this.usersdgv.MultiSelect = false;
            this.usersdgv.Name = "usersdgv";
            this.usersdgv.ReadOnly = true;
            this.usersdgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.usersdgv.ShowEditingIcon = false;
            this.usersdgv.Size = new System.Drawing.Size(796, 364);
            this.usersdgv.TabIndex = 0;
            this.usersdgv.Click += new System.EventHandler(this.usersdgv_Click);
            // 
            // ViewAllUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(796, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ViewAllUsers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Users";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersdgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox type_selection;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox search_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.TextBox count_pagination;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView usersdgv;
    }
}