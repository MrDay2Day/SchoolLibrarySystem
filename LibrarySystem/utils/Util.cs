using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using LibrarySystem;
using LibrarySystem.Windows;

namespace CarRental.Utils
{
    public static class UtilityFunctions
    {
        public static void ShowMdiChild<T>(Form parent = null) where T : Form, new()
        {
            // Check if the form is already open
            foreach (Form form in parent.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate(); // Bring the existing form to the front
                    return; // Exit to prevent multiple instances
                }
            }

            // Create and show the form if not already open
            T childForm = new T();
            if (parent != null)
            {
                childForm.MdiParent = parent;
            };
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        public static void ShowMdiChild<T>(Form parent = null, User user = null) where T : Form
        {
            // Check if the form is already open
            foreach (Form form in parent.MdiChildren)
            {
                if (form is T)
                {
                    form.Activate(); // Bring the existing form to the front
                    return; // Exit to prevent multiple instances
                }
            }

            // Create and show the form if not already open
            T childForm;
            if (user != null)
            {
                var constructor = typeof(T).GetConstructor(new[] { typeof(User) });
                if (constructor != null)
                {
                    childForm = (T)constructor.Invoke(new object[] { user });
                }
                else
                {
                    throw new ArgumentException($"No constructor found in {typeof(T).Name} that accepts {typeof(User).Name}.");
                }
            }
            else
            {
                childForm = (T)Activator.CreateInstance(typeof(T));
            }

            if (parent != null)
            {
                childForm.MdiParent = parent;
            }
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        public static void ShowMdiChild<T, U>(U passObject = default, Form parent = null) where T : Form
        {
            // Ensure parent is not null before checking MDI children
            if (parent != null)
            {
                foreach (Form form in parent.MdiChildren)
                {
                    if (form is T)
                    {
                        form.Activate();
                        return;
                    }
                }
            }

            T childForm;

            // Use reflection to create an instance with the correct constructor
            if (passObject != null)
            {
                var constructor = typeof(T).GetConstructor(new[] { typeof(U) });
                if (constructor != null)
                {
                    childForm = (T)constructor.Invoke(new object[] { passObject });
                }
                else
                {
                    throw new ArgumentException($"No constructor found in {typeof(T).Name} that accepts {typeof(U).Name}.");
                }
            }
            else
            {
                childForm = (T)Activator.CreateInstance(typeof(T));
            }

            // Set MDI Parent if provided
            if (parent != null)
            {
                childForm.MdiParent = parent;
            }

            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }




        public static void CloseAll(Form parent = null)
        {
            foreach (Form form in parent.MdiChildren)
            {
                form.Close();
            }
        }


        public static bool OpenAsDialog<F>() where F : Form, new()
        {
            try
            {
               using(F element = (new F()))
                {
                    if (element.ShowDialog() == DialogResult.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception)
            {

                WarningPopUp popup = new WarningPopUp("Systen Error", "System Error", "That seems to be a critical error with the system, Please contact support.");
                return false;
            }
        }

        public static string EncryptPassword(string password)
        {
            /**
             * To encrypt password we have a couple steps
             * 
             *      Install "System.Security.Cryptography" Library
             *      Create instancfe of hasher
             *      Hash password in to byte array
             *      Create instance of string builder
             *      Build hash string from byte array elements
             *      Store hash string to a string variable
             *
             */
            // Encrypting Password
            SHA256 sha = new SHA256Managed();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            // Create string from bytes
            StringBuilder sBuilder = new StringBuilder();
            foreach (var b in data)
            {
                sBuilder.Append(b.ToString("x2"));
            }
            string hash_password = sBuilder.ToString();

            return hash_password;
        }
    }
}
