using System.Security.Cryptography;
using System.Text;
using LibrarySystemWeb.Data;
using LibrarySystemWeb.Models;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystemWeb.Utils.Auth
{

    public class UserService : IUserService
    {
        private readonly LibrarySystemContext _db;

        public UserService(LibrarySystemContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            try
            {
                Console.WriteLine($"Validating user: {email}");

                // Hash the password
                using SHA256 sha = SHA256.Create();
                byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();

                foreach (var b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }

                string hashedPassword = sBuilder.ToString();
                Console.WriteLine("Password hashed successfully");

                // Find the user
                var user = _db.Users.FirstOrDefault(u =>
                    u.Email == email && u.Password == hashedPassword);

                Console.WriteLine($"User lookup result: {(user != null ? "Found" : "Not found")}");

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in ValidateUserAsync: {ex.Message}");
                throw; // Rethrow to be caught by the caller
            }
        }

        public User UpdateUser(User updatedUserInfo)
        {
            try
            {
                return updatedUserInfo;
            }
            catch (Exception err)
            {

                throw err;
            }
           
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            // Assuming you have a DbContext or repository
            // This example uses EF Core
            return await _db.Users.FindAsync(userId);

            // If you're using ADO.NET directly with stored procedures
            // You'll need to implement the data access accordingly
        }

        // Add to IUserService interface
        //Task<bool> UpdateUserAsync(int userId, UserUpdate model);

        // Implementation in UserService
        public async Task<bool> UpdateUserAsync(int userId, UserUpdate model)
        {
            // Find the user
            var user = await _db.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            // Update user properties
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Phone = model.Phone;

            // Only update password if provided
            if (!string.IsNullOrEmpty(model.Password))
            {
                // Hash the new password
                user.Password = HashPassword(model.Password); // Implement your password hashing method
            }

            // Save changes
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Example password hashing method (replace with your actual method)
        private string HashPassword(string password)
        {
       
            using SHA256 sha = SHA256.Create();
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();

            foreach (var b in data)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            string hashedPassword = sBuilder.ToString();

            return hashedPassword;
        }
    }
}