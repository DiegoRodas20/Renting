using GtMotive.Renting.Modules.Customers.Domain.Activities;
using GtMotive.Renting.Modules.Customers.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Customers.Infrastructure.Activities;

internal sealed class ActivityRepository(CustomersDbContext context) : IActivityRepository
{
    public async Task<List<Activity>> GetActivities()
    {
        var activities = await context.Activities.ToListAsync();

        return activities;
    }

    public async Task InsertActivity(Activity rental)
    {
        await context.Activities.AddAsync(rental);
        await context.SaveChangesAsync();
    }
}
