using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker
{
    public class LocationTrackerContext : DbContext, ILocationTrackerContext
    {
        public LocationTrackerContext(DbContextOptions<LocationTrackerContext> options)
            : base(options) { }

        public DbSet<Location> Locations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}