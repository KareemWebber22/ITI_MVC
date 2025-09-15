using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace ITI_MVC.Models
{
    public class ITIContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        public ITIContext():base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle
                ("Data Source=met;User ID=KAREEM;Password=KAREEM");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
