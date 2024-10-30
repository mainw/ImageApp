using Microsoft.EntityFrameworkCore;
using API.ImageService.Models;


namespace API.ImageService.DataBaseContext
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.IdUser);
        }
    }
}
