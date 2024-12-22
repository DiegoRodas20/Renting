namespace GtMotive.Renting.Modules.Customers.Domain.Activities;

public class Activity
{
    public Guid Id { get; private set; }

    public Guid CustomerId { get; private set; }

    public ActivityType ActivityType { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public static Activity Create(
        Guid customerId,
        ActivityType activityType
    )
    {
        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            ActivityType = activityType,
            CreatedAt = DateTime.UtcNow
        };

        return activity;
    }
}
