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
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ImageAppDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasKey(u => u.IdUser);

            //// Конфигурация для Image
            //modelBuilder.Entity<Image>()
            //    .HasKey(i => i.IdImage);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.IdUser);
        }
    }
}
