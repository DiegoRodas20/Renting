namespace GtMotive.Renting.Modules.Customers.Domain.Activities;

public interface IActivityRepository
{
    Task<List<Activity>> GetActivities();

    Task InsertActivity(Activity rental);
}