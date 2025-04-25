using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories;

public class PropertiesRepository : IPropertiesRepository
{
    private readonly PropertiesDbContext _dbContext;

    public PropertiesRepository(PropertiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Property property)
    {
        _dbContext.Add(property);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Property?> GetById(Guid id)
    {
        return _dbContext.Properties.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<Property>> List()
    {
        return _dbContext.Properties.ToListAsync();
    }

    public async Task Update(Property property)
    {
        Property? existingProperty = await GetById(property.Id);

        if (existingProperty is null)
        {
            throw new InvalidOperationException($"Property with id {property.Id} does not exist");
        }

        existingProperty.Name = property.Name;
    }

    public async Task DeleteById(Guid id)
    {
        Property? existingProperty = await GetById(id);

        if (existingProperty is null)
        {
            throw new InvalidOperationException($"Property with id {id} does not exist");
        }

        _dbContext.Properties.Remove(existingProperty);
        await _dbContext.SaveChangesAsync();
    }
}
