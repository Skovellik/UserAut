using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UserAut.Models;

namespace UserAut.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=ManagementDb")
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AppDbContext>(null);

            modelBuilder.Entity<User>().ToTable("User");

            base.OnModelCreating(modelBuilder);
        }
    }
}
