namespace GtMotive.Renting.Modules.Vehicles.Domain.Categories;

public sealed class Category
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public static Category Create(string name, string description)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description
        };

        return category;
    }
}
