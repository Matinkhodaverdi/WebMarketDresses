using Microsoft.EntityFrameworkCore;
using WebMarketDress.DataAccess;
using WebMarketDress.DataAccess.Service;
using WebMarketDress.DataAccess.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using WebMarketDress.Utility;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefualtConnection")
    ));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();




builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICoverTypeService, CoverTypeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();



builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/Access/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
