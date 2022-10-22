using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppIdentityDbContext : IdentityDbContext
{
    public AppIdentityDbContext()
    {
    }

    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seeding dummy users for use in testing
        // Seeding roles
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2c5c1e4e-3b0e-446f-82f-423d16fd7c10", Name = "Employee",
                NormalizedName = "EMPLOYEE".ToUpper()
            },
            new IdentityRole
            {
                Id = "8j2c1i4m-0b2h-837d-8j3-482k14fk7c92", Name = "Student",
                NormalizedName = "STUDENT".ToUpper()
            });
        
        // Making a hasher to hash the password before seeding it
        var hasher = new PasswordHasher<IdentityUser>();
        
        //Seeding the User to AspNetUsers table
        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "8e482735-a24d-43543-a6c6-9273d048kdj9",
                UserName = "lucas@email.com", NormalizedUserName = "LUCAS@EMAIL.COM".ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "AvansVoedselVerspilling")
            },
            new IdentityUser
            {
                Id = "8e728335-a24d-49283-a6c6-9827d048opj9",
                UserName = "jaron@email.com", NormalizedUserName = "JARON@EMAIL.COM".ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "AvansVoedselVerspilling")
            },
            new IdentityUser
            {
                Id = "4e401827-a93d-43543-a6c6-9273d048kdj9",
                UserName = "quinn@email.com", NormalizedUserName = "QUINN@EMAIL.COM".ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "AvansVoedselVerspilling")
            },
            new IdentityUser
            {
                Id = "5e928372-a54d-48373-a6c6-9827p046kdj9",
                UserName = "hansgerard@email.com", NormalizedUserName = "HANSGERARD@EMAIL.COM".ToUpper(),
                PasswordHash = hasher.HashPassword(null!, "AvansVoedselVerspilling")
            }
        );


        //Seeding the relation between our user and role to AspNetUserRoles table
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "8j2c1i4m-0b2h-837d-8j3-482k14fk7c92",
                UserId = "8e482735-a24d-43543-a6c6-9273d048kdj9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "8j2c1i4m-0b2h-837d-8j3-482k14fk7c92",
                UserId = "8e728335-a24d-49283-a6c6-9827d048opj9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5c1e4e-3b0e-446f-82f-423d16fd7c10",
                UserId = "4e401827-a93d-43543-a6c6-9273d048kdj9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5c1e4e-3b0e-446f-82f-423d16fd7c10",
                UserId = "5e928372-a54d-48373-a6c6-9827p046kdj9"
            }
        );
    }
}