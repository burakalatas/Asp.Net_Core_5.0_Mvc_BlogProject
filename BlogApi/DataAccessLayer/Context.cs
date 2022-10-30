using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MJ87N70\\SQLEXPRESS; database=CoreBlogAPI; integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
