using DL.entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DataContext : DbContext, IDataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=number1_db");
        }
        public int SaveChanges()
        {
            return base.SaveChanges();
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Baby> Babies { get; set; }
    }
}