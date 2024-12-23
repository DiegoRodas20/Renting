using GtMotive.Renting.Modules.Vehicles.Domain.Categories;
using GtMotive.Renting.Modules.Vehicles.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Renting.Modules.Vehicles.Infrastructure.Categories;

internal sealed class CategoryRepository(VehiclesDbContext context) : ICategoryRepository
{
    public async Task<List<Category>> GetCategories()
    {
        var categories = await context.Categories.ToListAsync();

        return categories;
    }

    public async Task InsertCategory(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }
}
