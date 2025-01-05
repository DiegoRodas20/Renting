namespace GtMotive.Renting.Modules.Vehicles.Domain.Categories;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategories();

    Task<Category?> GetCategoryById(Guid categoryId);

    Task InsertCategory(Category category);
}