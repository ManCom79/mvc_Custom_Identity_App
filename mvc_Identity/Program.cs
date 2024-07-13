using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvc_Identity.Models;
using mvc_Identity.Data;
using mvc_Identity.Data.Implementations;
using mvc_Identity.Data.Interfaces;
using mvc_Identity.Services.Interfaces;
using mvc_Identity.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IRentService, RentService>();
builder.Services.AddTransient<IMovieDataTableRepository, MovieDataTableRepository>();
builder.Services.AddTransient<IRentDataTableRepository, RentDataTableRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

app.Run();
