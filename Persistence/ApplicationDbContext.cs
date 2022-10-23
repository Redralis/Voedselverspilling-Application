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
    }

    public DbSet<Student> Student { get; set; } = null!;

    public DbSet<Product> Product { get; set; } = null!;

    public DbSet<MealBox> MealBox { get; set; } = null!;

    public DbSet<Employee> Employee { get; set; } = null!;

    public DbSet<Canteen> Canteen { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Adding constraints
        // Student cannot be born in future
        modelBuilder.Entity<Student>(m => m.ToTable(t =>
            t.HasCheckConstraint("CK_DateOfBirth_NotInFuture", "DateOfBirth <= GetDate()")));

        // Student cannot be under 16 years old
        modelBuilder.Entity<Student>(m => m.ToTable(t =>
            t.HasCheckConstraint("CK_DateOfBirth_NotUnder16", "DateOfBirth <= DATEADD(yyyy,-16,getdate())")));

        // Seeded data for testing
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
                    Id = 2, Name = "Jaron", DateOfBirth = "2005-01-19", StudentNr = "2194746",
                    Email = "jaron@email.com", City = "Dordrecht", PhoneNr = "0682731928"
                });

        // Making products
        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Id = 1, Name = "Wit brood", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/2942327/pexels-photo-2942327.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 2, Name = "Bruin brood", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/8599720/pexels-photo-8599720.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 3, Name = "Kippenpoten", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/3926125/pexels-photo-3926125.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 4, Name = "Taart", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/2144112/pexels-photo-2144112.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 5, Name = "Cola", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/50593/coca-cola-cold-drink-soft-drink-coke-50593.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 6, Name = "Limonade", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/96974/pexels-photo-96974.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 7, Name = "Bier", IsAlcoholic = true,
                    Photo =
                        "https://images.pexels.com/photos/1552630/pexels-photo-1552630.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 8, Name = "Vodka", IsAlcoholic = true,
                    Photo =
                        "https://images.pexels.com/photos/1170599/pexels-photo-1170599.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 9, Name = "IJs", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/1294943/pexels-photo-1294943.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 10, Name = "Macarons", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/3776947/pexels-photo-3776947.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 11, Name = "Popcorn", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/33129/popcorn-movie-party-entertainment.jpg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 12, Name = "Chips", IsAlcoholic = false,
                    Photo =
                        "https://images.pexels.com/photos/568805/pexels-photo-568805.jpeg?auto=compress&cs=tinysrgb&w=500&h=500&dpr=1"
                },
                new Product
                {
                    Id = 13, Name = "Blauw Kristalsnoep", IsAlcoholic = false,
                    Photo =
                        "https://video-images.vice.com/_uncategorized/1491919892314-Blue-Sky-Candy-1.jpeg?resize=500:*"
                },
                new Product
                {
                    Id = 14, Name = "Normaal Kristalsnoep", IsAlcoholic = false,
                    Photo =
                        "https://cdn11.bigcommerce.com/s-1b75a/images/stencil/500w/products/138/3144/DSCN1797__13248.1652210117.JPG?c=2"
                });

        modelBuilder.Entity<Canteen>()
            .HasData(
                new Canteen
                {
                    Id = 1, City = "Breda", Address = "Lovensdijkstraat 61", ServesWarmMeals = true
                },
                new Canteen
                {
                    Id = 2, City = "Breda", Address = "Lovensdijkstraat 63", ServesWarmMeals = true
                },
                new Canteen
                {
                    Id = 3, City = "Tilburg", Address = "Professor Cobbenhagenlaan 13", ServesWarmMeals = false
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
                    Id = 2, Name = "Hans Gerard", Email = "hansgerard@email.com", EmployeeNr = "2193726", CanteenId = 3
                });

        // Making MealBoxes
        // 4 pickup times
        DateTime box1Time = new DateTime(2022, 11, 11, 15, 00, 0);
        DateTime box2Time = new DateTime(2022, 11, 5, 13, 30, 0);
        DateTime box3Time = new DateTime(2022, 11, 17, 12, 00, 0);
        DateTime box4Time = new DateTime(2022, 11, 20, 18, 30, 0);
        DateTime box5Time = new DateTime(2022, 11, 22, 14, 20, 0);
        DateTime box6Time = new DateTime(2022, 11, 26, 16, 15, 0);

        modelBuilder.Entity<MealBox>()
            .HasData( 
                new MealBox
                {
                    Id = 1, Name = "Brood assortiment", City = "Breda",
                    PickUpTime = box1Time, PickUpBy = box1Time.AddDays(1), IsEighteen = false, Price = 22.50m,
                    MealType = "Brood box", CanteenId = 1, IsWarmMeal = false
                },
                new MealBox
                {
                    Id = 2, Name = "Warme maaltijd", City = "Breda",
                    PickUpTime = box2Time, PickUpBy = box2Time.AddDays(2), IsEighteen = false, Price = 5.25m,
                    MealType = "Warm eten", CanteenId = 2, IsWarmMeal = true
                },
                new MealBox
                {
                    Id = 3, Name = "Drank arrangement", City = "Breda",
                    PickUpTime = box3Time, PickUpBy = box3Time.AddDays(1), IsEighteen = false, Price = 15.50m,
                    MealType = "Drank box", CanteenId = 2, IsWarmMeal = false
                },
                new MealBox
                {
                    Id = 4, Name = "Alcohol arrangement", City = "Breda",
                    PickUpTime = box4Time, PickUpBy = box4Time.AddDays(1), IsEighteen = true, Price = 30.00m,
                    MealType = "Alcohol box", CanteenId = 1, IsWarmMeal = false
                },
                new MealBox
                {
                    Id = 5, Name = "Dessert mix", City = "Breda",
                    PickUpTime = box5Time, PickUpBy = box5Time.AddDays(1), IsEighteen = false, Price = 17.50m,
                    MealType = "Dessert box", StudentId = 1, CanteenId = 1, IsWarmMeal = false
                },
                new MealBox
                {
                    Id = 6, Name = "Snacks", City = "Tilburg",
                    PickUpTime = box6Time, PickUpBy = box6Time.AddDays(1), IsEighteen = false, Price = 7.50m,
                    MealType = "Warm eten", CanteenId = 3, IsWarmMeal = true
                },
                new MealBox
                {
                    Id = 7, Name = "Jesse Pinkman Meth Deluxe Snoep", City = "Breda",
                    PickUpTime = box3Time, PickUpBy = box4Time.AddDays(1), IsEighteen = true, Price = 100.00m,
                    MealType = "Snoep", CanteenId = 1, IsWarmMeal = false
                });

        modelBuilder.Entity<MealBox>()
            .HasMany(m => m.Products)
            .WithMany(p => p.MealBoxes)
            .UsingEntity<Dictionary<string, object>>(
                "MealBoxProduct",
                r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                l => l.HasOne<MealBox>().WithMany().HasForeignKey("MealBoxId"),
                je =>
                {
                    je.HasKey("ProductId", "MealBoxId");
                    je.HasData(
                        new { MealBoxId = 1, ProductId = 1 },
                        new { MealBoxId = 1, ProductId = 2 },
                        new { MealBoxId = 2, ProductId = 3 },
                        new { MealBoxId = 2, ProductId = 5 },
                        new { MealBoxId = 2, ProductId = 4 }, 
                        new { MealBoxId = 3, ProductId = 5 },
                        new { MealBoxId = 3, ProductId = 6 },
                        new { MealBoxId = 4, ProductId = 7 },
                        new { MealBoxId = 4, ProductId = 8 },
                        new { MealBoxId = 5, ProductId = 9 },
                        new { MealBoxId = 5, ProductId = 10 },
                        new { MealBoxId = 6, ProductId = 11 },
                        new { MealBoxId = 6, ProductId = 12 },
                        new { MealBoxId = 6, ProductId = 6 },
                        new { MealBoxId = 7, ProductId = 13 },
                        new { MealBoxId = 7, ProductId = 14 }
                        );
                });
        
    }
}