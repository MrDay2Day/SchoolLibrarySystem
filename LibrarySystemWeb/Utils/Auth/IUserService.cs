using LibrarySystemWeb.Models;

namespace LibrarySystemWeb.Utils.Auth
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string email, string password);

        Task<User> GetUserByIdAsync(int userId);

        Task<bool> UpdateUserAsync(int userId, UserUpdate model);
    }
}
