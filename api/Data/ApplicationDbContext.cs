using api.Entity;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        List<IdentityRole> identityRoles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(identityRoles);
    }

}
