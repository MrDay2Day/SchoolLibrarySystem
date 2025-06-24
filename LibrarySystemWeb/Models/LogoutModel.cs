using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibrarySystemWeb.Utils.Auth;

namespace LibrarySystemWeb.Models
{
    public class LogoutModel : PageModel
    {
        private readonly CustomAuthStateProvider _authStateProvider;

        public LogoutModel(CustomAuthStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task OnGet()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // 🔔 Notify Blazor immediately about auth state change
            _authStateProvider.NotifyAuthenticationStateChangedManually();

            Response.Redirect("/");
        }
    }
}
