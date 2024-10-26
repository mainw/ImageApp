using Microsoft.EntityFrameworkCore;
using Serilog;
using ServiceLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceLib.DataBaseContext
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
