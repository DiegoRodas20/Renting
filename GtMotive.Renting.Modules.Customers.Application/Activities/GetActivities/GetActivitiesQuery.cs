using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Customers.Domain.Activities;

namespace GtMotive.Renting.Modules.Customers.Application.Activities.GetActivities;

public sealed record GetActivitiesQuery : IQuery<IReadOnlyCollection<Activity>>;