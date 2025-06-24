using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LibrarySystem.Windows
{
    public partial class ViewAllUsers : Form
    {
        private User systemUser;
        private Library_SystemEntities db;

        private int pageNum = 1; // Current page number
        private int perPage = 30; // Number of items per page
        private string userType = "";
        private int totalCount = 0;
        private int maxPages = 0;

        public ViewAllUsers(User user)
        {
            InitializeComponent();
            this.systemUser = user;
            this.db = new Library_SystemEntities();
            this.WindowState = FormWindowState.Maximized;

            // Load user types into the combo box
            LoadUserTypes();
            LoadDataTable();
            btn_search.Enabled = true;
        }

        private void LoadUserTypes()
        {
            type_selection.Items.Add("All"); // Add "All" option
            type_selection.Items.Add("USER");
            type_selection.Items.Add("ADMIN");
            type_selection.Items.Add("STAFF");
            type_selection.SelectedIndex = 0; // Select "All" by default
        }

        private void LoadDataTable()
        {
            usersdgv.DataSource = null;
            usersdgv.DataSource = GetUsersData();

            if (!usersdgv.Columns.Contains("Blocked"))
            {
                DataGridViewCheckBoxColumn blockedColumn = new DataGridViewCheckBoxColumn();
                blockedColumn.DataPropertyName = "Blocked";
                blockedColumn.HeaderText = "Blocked";
                usersdgv.Columns.Add(blockedColumn);
            }

            usersdgv.Columns[0].HeaderText = "User ID";
            usersdgv.Columns[1].HeaderText = "First Name";
            usersdgv.Columns[2].HeaderText = "Last Name";
            usersdgv.Columns[7].HeaderText = "Borrow Count";

            usersdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private List<UserWithBorrowCount> GetUsersData()
        {
            try
            {
                var query = db.Users.AsQueryable();

                if (!string.IsNullOrEmpty(search_text.Text))
                {
                    string searchText = search_text.Text.ToLower();
                    query = query.Where(u => u.First_name.ToLower().Contains(searchText) ||
                                           u.Last_name.ToLower().Contains(searchText) ||
                                           u.Email.ToLower().Contains(searchText));
                }

                if (type_selection.SelectedItem != null && type_selection.SelectedItem.ToString() != "All")
                {
                    query = query.Where(u => u.Type == type_selection.SelectedItem.ToString());
                }

                var usersWithBorrowCount = query.Select(u => new UserWithBorrowCount
                {
                    User_id = u.User_id,
                    First_name = u.First_name,
                    Last_name = u.Last_name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Type = u.Type,
                    Blocked = u.Blocked,
                    BorrowCount = db.Borrows.Count(b => b.User_id == u.User_id && b.Actual_return_date == null)
                });

                int total = usersWithBorrowCount.Count();
                this.totalCount = total;
                count.Text = total.ToString();

                int limit = ((pageNum - 1) * perPage);

                maxPages = (int)Math.Ceiling((double)total / perPage);

                count_pagination.Text = $"{(total < 1 ? 0 : limit + 1).ToString()} to " +
                                $"{(total < 1 ? 0 : limit + perPage > totalCount ? totalCount : (limit) + perPage).ToString()} of {totalCount}";


                return usersWithBorrowCount.OrderBy(u => u.User_id)
                                            .Skip((pageNum - 1) * perPage)
                                            .Take(perPage)
                                            .ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void search()
        {
            pageNum = 1; // Reset page number when searching
            LoadDataTable();
        }

        private void next()
        {
            if (pageNum < maxPages)
            {
                pageNum++;
                LoadDataTable();
            }
        }

        private void previous()
        {
            if (pageNum > 1)
            {
                pageNum--;
                LoadDataTable();
            }
        }

        private void selectedUser()
        {
            try
            {
                Console.WriteLine("CLICKED!");
                if (usersdgv.SelectedRows.Count > 0)
                {
                    var id = usersdgv.SelectedRows[0].Cells["User_id"].Value;
                    int userId = int.Parse(id.ToString());
                    Console.WriteLine($"User ID {userId}");


                    User user = db.Users.FirstOrDefault(u => u.User_id == userId);

                    db.Entry(user).Reload();

                    if (user == null) throw new Exception("Inavlid User");
                    Console.WriteLine($"User type: {user.Type}");


                    using (CreateUser userAccount = (new CreateUser(user, true)))
                    {
                        if (userAccount.ShowDialog() != DialogResult.OK)
                        {
                            LoadDataTable();
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Something Went Wrong", "Something went wrong fetching this user's information. Please contact support");
            }
        }

        private void selectedUserNewContext()
        {
            try
            {
                Console.WriteLine("CLICKED!");
                if (usersdgv.SelectedRows.Count > 0)
                {
                    var id = usersdgv.SelectedRows[0].Cells["User_id"].Value;
                    int userId = int.Parse(id.ToString());
                    Console.WriteLine($"User ID {userId}");

                    using (var newDb = new Library_SystemEntities()) // Create a new context
                    {
                        User user = newDb.Users.FirstOrDefault(u => u.User_id == userId);

                        if (user == null) throw new Exception("Inavlid User");
                        Console.WriteLine($"User type: {user.Type}");

                        using (CreateUser userAccount = (new CreateUser(user, true)))
                        {
                            if (userAccount.ShowDialog() != DialogResult.OK)
                            {
                                LoadDataTable();
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Something Went Wrong", "Something went wrong fetching this user's information. Please contact support");
            }
        }



        // Helper class to hold user data and borrow count
        public class UserWithBorrowCount
        {
            public int User_id { get; set; }
            public string First_name { get; set; }
            public string Last_name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Type { get; set; }
            public bool Blocked { get; set; }
            public int BorrowCount { get; set; }
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            previous();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            next();
        }

        private void type_selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            search();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            type_selection.SelectedIndex = 0;
            pageNum = 1;
            search_text.Text = null;
            search();
        }

        private void usersdgv_Click(object sender, EventArgs e)
        {
            selectedUser();
        }
    }
}