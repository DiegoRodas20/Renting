using GtMotive.Renting.Modules.Vehicles.Domain.Categories;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Categories;

internal sealed class CategoryRepository : ICategoryRepository
{
    public Task<List<Category>> GetCategories()
    {
        throw new NotImplementedException();
    }

    public Task InsertCategory(Category category)
    {
        throw new NotImplementedException();
    }
}
