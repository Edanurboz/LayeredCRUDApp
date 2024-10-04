using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class Proje:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-F05FEVIV\SQLEXPRESS;Database=Proje;Trusted_Connection=true");
        }

        public DbSet<Person> Person { get; set; }
    }
}
