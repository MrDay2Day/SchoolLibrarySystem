using System.Security.Claims;
using LibrarySystemWeb.Models;
using LibrarySystemWeb.Services;
using LibrarySystemWeb.Utils.Auth;
using LibrarySystemWeb.Utils.Auth.RouteFilter;
using LibrarySystemWeb.Utils.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly CustomAuthStateProvider _authStateProvider;
        private readonly BooksService _booksService;
        private readonly UserServices _userServiceFunction;

        public HomeController(IUserService userService, CustomAuthStateProvider authStateProvider, BooksService booksService, UserServices userServiceFunction)
        {
            _userService = userService;
            _authStateProvider = authStateProvider;
            _booksService = booksService;
            _userServiceFunction = userServiceFunction;
        }

        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            // Fetch paginated books and total count
            var (books, totalCount) = await _booksService.GetBooksPaginatedAsync(pageNumber, pageSize);

            // Calculate the total number of pages
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Create the model to pass to the view
            var model = new IndexViewModel
            {
                Books = books,
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(model);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserModel());
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel model)
        {
            bool registered = _userServiceFunction.RegisterUser(model);
            if (registered == true)
            {
                model.Message = "Registration Successful!";
                model.Registered = true;
            }
            else
            {
                model.Message = "Registration Failed!";
                model.Registered = false;
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Account()
        {
            // Get the userId from the Claims
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null)
            {
                return RedirectToAction("Login");
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login");
            }

            // Get the user data from your user service
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Create and populate the UserUpdate model
            var userUpdateModel = new UserUpdate
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                // Don't set Password and RetypePassword - they should be empty for security reasons
            };

            return View(userUpdateModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateAccount(UserUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return View("Account", model);
            }

            // Get the userId from Claims
            var userIdClaim = User.FindFirst("UserId");
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return RedirectToAction("Login");
            }

            try
            {
                // Update the user information
                bool success = await _userService.UpdateUserAsync(userId, model);
        
                if (success)
                {
                    // If you need to update the authentication cookie with new values
                    await UpdateAuthCookieAsync(userId);
            
                    // Add success message
                    TempData["SuccessMessage"] = "Your account has been updated successfully!";
                }
                else
                {
                    // Add error message
                    ModelState.AddModelError("", "Unable to update your information. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error updating user: {ex.Message}");
                ModelState.AddModelError("", "An error occurred while updating your information.");
            }

            // Get updated user data
            var updatedUser = await _userService.GetUserByIdAsync(userId);
            if (updatedUser == null)
            {
                return RedirectToAction("Login");
            }

            // Repopulate the model with updated data, but clear passwords
            var updatedModel = new UserUpdate
            {
                FirstName = updatedUser.FirstName,
                LastName = updatedUser.LastName,
                Email = updatedUser.Email,
                Phone = updatedUser.Phone
            };

            return View("Account", updatedModel);
        }

        // Helper method to update auth cookie after profile changes
        private async Task UpdateAuthCookieAsync(int userId)
        {
            // Get updated user data
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null) return;

            // Sign out the current user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Create new claims with updated information
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Individual"),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
                new Claim("UserType", user.Type.ToString()),
                new Claim("UserId", user.UserId.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // Sign in with the new claims
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(1)
                });

            // Notify Blazor about the auth state change
            _authStateProvider.NotifyAuthenticationStateChangedManually();
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyBooks()
        {
            return View();
        }



        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        [AdminOnly]
        public IActionResult AdminOnly()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UsersOnly()
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType != "USER")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                model.Message = "Please fill in all required fields.";
                return View(model);
            }

            try
            {
                User user = await _userService.ValidateUserAsync(model.Email, model.Password);

                if (user == null)
                {
                    model.Message = "Invalid email or password.";
                    return View(model);
                }

                if (user.Blocked)
                {
                    model.Message = "Your account has been blocked please contact library staff for assistance.";
                    return View(model);
                }

                UserInfo info = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserId = user.UserId,
                    UserType = user.Type
                };
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(ClaimTypes.Role, "Individual"),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("UserType", user.Type.ToString()),
                    new Claim("UserId", user.UserId.ToString())
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddHours(1)
                    });

                // Notify Blazor immediately about auth state change
                _authStateProvider.NotifyAuthenticationStateChangedManually();

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");

                }


            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error during login: {ex.Message}");
                model.Message = "An error occurred during login.";
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}