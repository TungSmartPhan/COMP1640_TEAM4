using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace COMP1640_TEAM4.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<IdeaUser> Idea { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Department> Departments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}