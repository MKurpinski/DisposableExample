using Microsoft.EntityFrameworkCore;

namespace DisposableExample
{
    public class MyContext: DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DisposableExample;Trusted_Connection=True;");
        }
    }
}
