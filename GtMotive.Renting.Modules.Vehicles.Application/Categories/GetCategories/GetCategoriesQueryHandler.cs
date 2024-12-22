using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Categories;

namespace GtMotive.Renting.Modules.Vehicles.Application.Categories.GetCategories;

internal sealed class GetCategoriesQueryHandler(

   ICategoryRepository categoryRepository

) : IQueryHandler<GetCategoriesQuery, IReadOnlyCollection<Category>>
{
    public async Task<Result<IReadOnlyCollection<Category>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<Category> result = await categoryRepository.GetCategories();

        return result;
    }
}