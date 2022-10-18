using Domain;
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

    
    public DbSet<Student> Student { get; set; }
    
    public DbSet<Employee> Employee { get; set; }
    
}