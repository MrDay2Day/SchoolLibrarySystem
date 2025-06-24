using System;
using System.Data.Entity;
using System.Windows.Forms;
using CarRental.Utils;

namespace LibrarySystem.Windows
{
    public partial class CreateUser : Form
    {
        private User systemUser = null;
        private Library_SystemEntities db;

        public CreateUser()
        {
            InitializeComponent();
            InitializeUserTypeComboBox();
            db = new Library_SystemEntities();
        }

        public CreateUser(User user)
        {
            InitializeComponent();
            InitializeUserTypeComboBox();
            this.systemUser = user;
            db = new Library_SystemEntities();

            this.Text = $"{systemUser.First_name}'s Account Information";

            combo_userType.Visible = false;
            form_title.Text = "Edit Profile";
            userTypeLable.Visible = false;

            this.autoaFill();
        }

        public CreateUser(User user, bool adminOnly)
        {
            InitializeComponent();
            InitializeUserTypeComboBox();
            this.systemUser = user;
            db = new Library_SystemEntities();
            

            this.Text = $"{systemUser.First_name}'s Account Information";

            combo_userType.Visible = true;
            form_title.Text = "Edit Profile";
            userTypeLable.Visible = true;
            block.Visible = true;
            info_password.Text = "";
            info_password_retype.Text = "";
            //info_password.Visible = false;
            //info_password_retype.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            this.autoaFill();
        }

        private void InitializeUserTypeComboBox()
        {
            combo_userType.Items.AddRange(new string[] { "ADMIN", "USER", "STAFF" });
            combo_userType.SelectedIndex = 1;
        }

        private void autoaFill()
        {
            if (systemUser != null)
            {
                this.info_first_name.Text = systemUser.First_name;
                this.info_last_name.Text = systemUser.Last_name;
                this.info_email.Text = systemUser.Email;
                this.info_phone.Text = systemUser.Phone;
                this.info_password.Text = null;
                this.info_password_retype.Text = null;
                this.block.Checked = systemUser.Blocked;

                Console.WriteLine($"Type is: {systemUser.Type}");

                if (combo_userType.Items.Contains(systemUser.Type))
                {
                    combo_userType.SelectedItem = systemUser.Type;
                }
                else if (combo_userType.Items.Count > 1)
                {
                    combo_userType.SelectedIndex = 1;
                }
            }
        }

        private void close()
        {
            systemUser = null;
            this.Close();
        }

        private void save()
        {
            if (systemUser == null)
            {
                CreateNewUser();
            }
            else
            {
                UpdateExistingUser();
            }
        }

        private void CreateNewUser()
        {
            try
            {
                string hashpw = UtilityFunctions.EncryptPassword(info_password.Text);

                if (string.IsNullOrEmpty(info_password.Text) || string.IsNullOrEmpty(info_password_retype.Text) || hashpw != UtilityFunctions.EncryptPassword(info_password_retype.Text))
                {
                    MessageBox.Show("Passwords do not match or are empty.");
                    return;
                }

                User newUser = new User
                {
                    First_name = info_first_name.Text,
                    Last_name = info_last_name.Text,
                    Email = info_email.Text,
                    Phone = info_phone.Text,
                    Password = hashpw,
                    Type = combo_userType.SelectedItem.ToString()
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                MessageBox.Show("User created successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}");
            }
        }

        private async void UpdateExistingUser()
        {
            try
            {


            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // Retrieve the user from the current context.
                    var userToUpdate = db.Users.Find(systemUser.User_id);

                    if (userToUpdate == null)
                    {
                        MessageBox.Show("User not found in the database.");
                        return;
                    }

                    userToUpdate.First_name = info_first_name.Text;
                    userToUpdate.Last_name = info_last_name.Text;
                    userToUpdate.Email = info_email.Text;
                    userToUpdate.Phone = info_phone.Text;
                    userToUpdate.Blocked = block.Checked;
                    userToUpdate.Type = combo_userType.SelectedItem.ToString();

                    Console.WriteLine($"Type is: {combo_userType.SelectedItem}");

                    if (!string.IsNullOrEmpty(info_password.Text))
                    {
                        if (info_password.Text == info_password_retype.Text)
                        {
                            userToUpdate.Password = UtilityFunctions.EncryptPassword(info_password.Text);
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match.");
                            return;
                        }
                    }

                    db.SaveChanges();
                    transaction.Commit();
                    MessageBox.Show("User information updated successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    transaction.Rollback();
                    MessageBox.Show($"Error updating user: {ex.Message}");
                }
            }
            }
            catch (Exception errr)
            {
                MessageBox.Show($"Error updating user: {errr.Message}");
            }
        }

        private void btn_save_new_Click(object sender, EventArgs e)
        {
            save();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            close();
        }

    }
}