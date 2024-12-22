using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Modules.Vehicles.Domain.Categories;

namespace GtMotive.Renting.Modules.Vehicles.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery : IQuery<IReadOnlyCollection<Category>>;