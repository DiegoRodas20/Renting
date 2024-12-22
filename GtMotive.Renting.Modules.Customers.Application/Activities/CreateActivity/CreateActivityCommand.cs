using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Customers.Domain.Activities;

namespace GtMotive.Renting.Modules.Customers.Application.Activities.CreateActivity;

public sealed record CreateActivityCommand(

    Guid CustomerId,

    ActivityType ActivityType

): ICommand<Guid>;