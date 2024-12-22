namespace GtMotive.Renting.Modules.Vehicles.Domain.Categories;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategories();

    Task InsertCategory(Category category);
}