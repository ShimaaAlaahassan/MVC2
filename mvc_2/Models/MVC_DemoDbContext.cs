using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace MVC2.Models
{
    public class MVC_DemoDbContext:DbContext
    {
        public MVC_DemoDbContext()
        {

        }
        public MVC_DemoDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-539NPC2;Initial Catalog=finial_MVC;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<location>().HasKey("DeptNumber", "Location");
            modelBuilder.Entity<workOn>().HasKey("ESSN", "projectNum");
           
            modelBuilder.Entity<employee>().HasOne(s => s.SuperVisor).WithMany(s => s.Employees);
            modelBuilder.Entity<employee>().HasOne(s => s.deptWork).WithMany(e => e.EmpWork);
            modelBuilder.Entity<employee>().HasOne(s => s.deptManage).WithOne(e => e.EmpManage);
        }
        public DbSet<Department> departments { get; set; }
        public DbSet<employee> employees { get; set; }
        public DbSet<Dependent> dependents { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<project> projects { get; set; }
        public DbSet<workOn> workOns { get; set; }
    }
}
