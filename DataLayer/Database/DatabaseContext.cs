using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string dbFile = "Welcome.db";
            string dbPath = Path.Combine(solutionFolder, dbFile);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            DatabaseUser user = new DatabaseUser()
            {
                Id = 1,
                Name = "John Doe",
                Password = "Abcd1234",
                Role = Weclome.Others.UserRolesEnum.ADMIN,
            };

            modelBuilder.Entity<DatabaseUser>().HasData(user);
        }
    }
}
