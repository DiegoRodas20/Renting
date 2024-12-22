using GtMotive.Renting.Common.Application.Messaging;
using GtMotive.Renting.Common.Domain;
using GtMotive.Renting.Modules.Vehicles.Domain.Categories;

namespace GtMotive.Renting.Modules.Vehicles.Application.Categories.CreateCategory;

internal sealed class CreateCategoryCommandHandler(

    ICategoryRepository categoryRepository

) : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Name, request.Description);

        await categoryRepository.InsertCategory(category);

        return category.Id;
    }
}
