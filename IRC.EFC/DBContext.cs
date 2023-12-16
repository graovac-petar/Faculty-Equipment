using IRC.Models;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC
{
    public class DBContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentAssignement> EquipmentAssignement { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Room> Room { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.Migrate();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IRC-EFC;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Room>().ToTable(nameof(Room));
            //modelBuilder.Entity<Equipment>().ToTable(nameof(Equipment));
            //modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            base.OnModelCreating(modelBuilder);
        }
    }
}
