using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Database.Repositories;

public class PropertiesRepository : IPropertiesRepository
{
    private readonly PropertiesDbContext _dbContext;

    public PropertiesRepository(PropertiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Property property)
    {
        _dbContext.Add(property);
        _dbContext.SaveChanges();
    }

    public Property? GetById(Guid id)
    {
        return _dbContext.Properties.FirstOrDefault(p => p.Id == id);
    }

    public List<Property> List()
    {
        return _dbContext.Properties.ToList();
    }

    public void Update(Property property)
    {
        Property? existingProperty = GetById(property.Id);

        if (existingProperty is null)
        {
            throw new InvalidOperationException($"Property with id {property.Id} does not exist");
        }

        existingProperty.Name = property.Name;
    }

    public void DeleteById(Guid id)
    {
        Property? existingProperty = GetById(id);

        if (existingProperty is null)
        {
            throw new InvalidOperationException($"Property with id {id} does not exist");
        }

        _dbContext.Properties.Remove(existingProperty);
        _dbContext.SaveChanges();
    }
}
