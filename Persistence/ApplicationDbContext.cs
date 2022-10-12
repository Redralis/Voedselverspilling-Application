using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("data source=LAPTOP-HM5F12SM;initial catalog=VoedselVerspillingDb;trusted_connection=true;TrustServerCertificate=True");

    public DbSet<Student> Student { get; set; }
    
    public DbSet<Product> Product { get; set; }
    
    public DbSet<Mealbox> MealBox { get; set; }
    
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<Canteen> Canteen { get; set; }
    
}