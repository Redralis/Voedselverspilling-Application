using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

var databaseConnection = builder.Configuration.GetConnectionString("CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("Connection");
var identityDatabaseConnection = builder.Configuration.GetConnectionString("IDENTITY_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("IdentityConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injecting identity database context
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    if (identityDatabaseConnection != null) options.UseSqlServer(identityDatabaseConnection);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>();


// Injecting database context and repositories
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (databaseConnection != null) options.UseSqlServer(databaseConnection);
});

builder.Services.AddScoped<ICanteenRepository, CanteenRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IMealBoxRepository, MealBoxRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();