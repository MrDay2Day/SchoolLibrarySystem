using System.Text;
using System.Security.Cryptography;
using LibrarySystemWeb.Data;
using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Services
{
    public class UserServices
    {
        private readonly LibrarySystemContext _context;

        public UserServices(LibrarySystemContext context)
        {
            _context = context;
        }

        public bool RegisterUser(RegisterUserModel registerUser)
        {
            try
            {
                using SHA256 sha = SHA256.Create();
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password));
                StringBuilder sBuilder = new StringBuilder();

                foreach (var b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }

                string hashedPassword = sBuilder.ToString();
                // Fetch top 'count' books from the database
                User newUser = new()
                {
                    Blocked = false,
                    Email = registerUser.Email,
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    Password = hashedPassword,
                    Type = "USER"
                };
                if (registerUser.Phone != null)
                {
                    newUser.Phone = registerUser.Phone;
                }

                _context.Users.Add(newUser);

                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


    }
}
