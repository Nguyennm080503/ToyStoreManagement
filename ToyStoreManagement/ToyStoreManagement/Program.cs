using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToyStoreManagement.Extension;
using ToyStoreService.Implement;
using ToyStoreService.Interface;

var builder = WebApplication.CreateBuilder(args);
	
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddService();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<ToyStoreDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, option =>
    {
        option.ClientId = builder.Configuration["Google:ClientId"];
        option.ClientSecret = builder.Configuration["Google:ClientSecret"];
    });

builder.Services.Configure<CookiePolicyOptions>(options =>
{
	// This lambda determines whether user consent for non-essential cookies is needed for a given request.
	options.CheckConsentNeeded = context => true;
	options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
});



builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseCookiePolicy(new CookiePolicyOptions()
{
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always,
	MinimumSameSitePolicy = SameSiteMode.Lax
});

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.Run();
