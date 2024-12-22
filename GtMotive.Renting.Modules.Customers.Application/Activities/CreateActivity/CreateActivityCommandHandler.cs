using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Customers.Domain.Activities;

namespace GtMotive.Renting.Modules.Customers.Application.Activities.CreateActivity;

internal sealed class CreateActivityCommandHandler(

    IActivityRepository activityRepository

) : ICommandHandler<CreateActivityCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var activity = Activity.Create(
            request.CustomerId,
            request.ActivityType
        );

        await activityRepository.InsertActivity(activity);

        return activity.Id;
    }
}