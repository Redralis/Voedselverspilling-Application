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
    
    public DbSet<MealBox> MealBox { get; set; }
    
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<Canteen> Canteen { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Making testing data for the database, starting with Student
        modelBuilder.Entity<Student>()
            .HasData(
                new Student
                {
                    Id = 1, Name = "Lucas", DateOfBirth = "2003-01-27", StudentNr = "2191372",
                    Email = "lucas@email.com", City = "Dordrecht", PhoneNr = "0692837263"
                },
                new Student
                {
                    Id = 2, Name = "Jaron", DateOfBirth = "2002-01-19", StudentNr = "2194746",
                    Email = "jaron@email.com", City = "Dordrecht", PhoneNr = "0682731928"
                });

        // Making products
        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1, Name = "Hot dog", IsAlcoholic = false, Photo = "Picture of a hot dog"
                },
                new Product
                {
                    Id = 2, Name = "Beer", IsAlcoholic = true, Photo = "Picture of a beer glass"
                },
                new Product
                {
                    Id = 3, Name = "Sandwich", IsAlcoholic = false, Photo = "Picture of a sandwich"
                });
        
    }
    
}