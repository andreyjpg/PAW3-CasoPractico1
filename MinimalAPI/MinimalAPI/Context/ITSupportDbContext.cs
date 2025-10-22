using Microsoft.EntityFrameworkCore;
using Ticket = MinimalAPI.Model.Ticket;

namespace MinimalAPI.Context
{
    public class ITSupportDbContext : DbContext
    {
        public ITSupportDbContext(DbContextOptions<ITSupportDbContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets => Set<Ticket>();
    }
}
