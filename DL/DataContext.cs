using DL.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DL
{
    public class DataContext : DbContext, IDataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=number1_db");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("YourConnectionString")
        //            .LogTo(Console.WriteLine, LogLevel.Information); // לוג לשורת הפקודה
        //    }
        //}


        public int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Baby> Babies { get; set; }
    }
}