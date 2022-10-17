using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
var connection = builder.Configuration.GetConnectionString("CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("Connection");

Console.WriteLine(connection + " <- connectionstring");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injecting database context and repositories
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    if (connection != null) options.UseSqlServer(connection);
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();