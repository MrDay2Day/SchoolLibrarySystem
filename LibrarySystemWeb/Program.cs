using LibrarySystemWeb.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using LibrarySystemWeb.Utils.Auth;
using LibrarySystemWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("CloudDB")
//                      ?? throw new InvalidOperationException("Connection string 'CloudDB' not found.");

//// Register database contexts
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<LibrarySystemContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Critical - register HttpContextAccessor BEFORE CustomAuthStateProvider
builder.Services.AddHttpContextAccessor();

// Authentication and Authorization setup
builder.Services.AddAuthorizationCore();

// Register CustomAuthStateProvider as concrete type FIRST
builder.Services.AddScoped<CustomAuthStateProvider>();

// THEN register it as the interface
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthStateProvider>());

// Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<UserServices>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.LogoutPath = "/Home/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

// Register MVC, Razor Pages, and Blazor
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapBlazorHub();

app.Run();