using Microsoft.EntityFrameworkCore;
using API.ImageService.Models;


namespace API.ImageService.DataBaseContext
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ImageAppDb;Trusted_Connection=True;");
        }
    }
}
