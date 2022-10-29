using Microsoft.EntityFrameworkCore;

namespace WebCoreAPI.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MJ87N70\\SQLEXPRESS; database=WebCoreAPI; integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
