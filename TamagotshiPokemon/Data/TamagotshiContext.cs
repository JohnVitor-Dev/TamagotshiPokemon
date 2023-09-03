using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using User.Model;

namespace Tamagotshi.Data
{
    public class TContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=Person.sqlite";
            optionsBuilder.UseSqlite(connectionString);
        }

        public DbSet<UserModel> UserInventory { get; set; }

    }
}
