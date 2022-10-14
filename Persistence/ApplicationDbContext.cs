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
    {
        options.UseSqlServer("data source=LAPTOP-HM5F12SM;initial catalog=VoedselVerspillingDb;trusted_connection=true;TrustServerCertificate=True");
    }
        

    public DbSet<Student> Student { get; set; }
    
    public DbSet<Product> Product { get; set; }
    
    public DbSet<MealBox> MealBox { get; set; }
    
    public DbSet<Employee> Employee { get; set; }
    
    public DbSet<Canteen> Canteen { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Making students
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
                },
                new Product
                {
                    Id = 4, Name = "Water", IsAlcoholic = false, Photo = "Picture of a bottle of water"
                });
        
        // Making canteens
        modelBuilder.Entity<Canteen>()
            .HasData(
                new Canteen
                {
                    Id = 1, City = "Breda", Address = "Lovensdijkstraat 61", ServesWarmMeals = true
                },
                new Canteen
                {
                    Id = 2, City = "Breda", Address = "Lovensdijkstraat 63", ServesWarmMeals = true
                });

        // Making employees
        modelBuilder.Entity<Employee>()
            .HasData(
                new Employee
                {
                    Id = 1, Name = "Quinn", Email = "quinn@email.com", EmployeeNr = "2187362", CanteenId = 1
                },
                new Employee
                {
                    Id = 2, Name = "Hans Gerard", Email = "hansgerard@email.com", EmployeeNr = "2193726", CanteenId = 2
                });
        
        // Making MealBoxes
        DateTime time = new DateTime(2022, 11, 5, 13, 30, 0);
        modelBuilder.Entity<MealBox>()
            .HasData(
                new MealBox
                {
                    Id = 1, Name = "Gezonde maaltijd box", City = "Breda", PickUpTime = time, 
                    PickUpBy = time.AddDays(1), IsEighteen = false, Price = 22.50m, MealType = "Box", StudentId = 1,
                    CanteenId = 1
                },
                new MealBox
                {
                    Id = 2, Name = "Zaterdagmiddag", City = "Breda", PickUpTime = time, 
                    PickUpBy = time.AddDays(2), IsEighteen = true, Price = 5.25m, MealType = "Box", CanteenId = 2
                },
                new MealBox
                {
                    Id = 3, Name = "Panini box", City = "Breda", PickUpTime = time, 
                    PickUpBy = time.AddDays(1), IsEighteen = false, Price = 15.50m, MealType = "Box", CanteenId = 2
                },
                new MealBox
                {
                    Id = 4, Name = "18+'ers box", City = "Breda", PickUpTime = time, 
                    PickUpBy = time.AddDays(1), IsEighteen = true, Price = 30.00m, MealType = "Box", CanteenId = 1
                });
        
        // Giving MealBoxes products
        modelBuilder.Entity<MealBox>()
            .HasMany(p => p.Product)
            .WithMany(p => p.MealBox)
            .UsingEntity(j => 
                j.HasData(
                    new
                    {
                        MealBoxId = 1, ProductId = 1
                    },
                    new
                    {
                        MealBoxId = 1, ProductId = 4
                    },
                    new
                    {
                        MealBoxId = 2, ProductId = 2
                    },
                    new
                    {
                        MealBoxId = 3, ProductId = 2
                    },
                    new
                    {
                        MealBoxId = 3, ProductId = 3
                    },
                    new
                    {
                        MealBoxId = 4, ProductId = 1
                    }));
        
    }
    
}