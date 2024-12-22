using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Customers.Domain.Activities;

namespace GtMotive.Renting.Modules.Customers.Application.Activities.GetActivities;

internal sealed class GetActivitiesQueryHandler(

    IActivityRepository activityRepository

) : IQueryHandler<GetActivitiesQuery, IReadOnlyCollection<Activity>>
{
    public async Task<Result<IReadOnlyCollection<Activity>>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
    {
        List<Activity> result = await activityRepository.GetActivities();

        return result;
    }
}