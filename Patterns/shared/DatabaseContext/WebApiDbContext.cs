using Microsoft.EntityFrameworkCore;
using shared.Domain;

namespace shared.DatabaseContext
{
  public class WebApiDbContext : DbContext
  {
        public WebApiDbContext() { }

        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            :base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Movement> Movement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
