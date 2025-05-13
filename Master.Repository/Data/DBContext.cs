using Master.Core.Entities;
using Master.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Master.Repository.Data
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }
        public DbSet<video> Videos { get; set; }

        // لو عندك جداول إضافية:
        // public DbSet<Course> Courses { get; set; }
        // public DbSet<Student> Students { get; set; }
    }
}
