using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker
{
    public interface ILocationTrackerContext
    {
        DbSet<Location> Locations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
    }
}