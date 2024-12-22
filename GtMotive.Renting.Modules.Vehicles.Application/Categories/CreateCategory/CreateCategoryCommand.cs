
using GtMotive.Renting.Common.Application.Messaging;

namespace GtMotive.Renting.Modules.Vehicles.Application.Categories.CreateCategory;

public sealed record CreateCategoryCommand(

    string Name,

    string Description

) : ICommand<Guid>;