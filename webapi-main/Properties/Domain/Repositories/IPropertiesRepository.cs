using Domain.Entities;

namespace Domain.Repositories;

public interface IPropertiesRepository
{
    Task Add(Property property);
    Task<Property?> GetById(Guid id);
    Task<List<Property>> List();
    Task Update(Property property);
    Task DeleteById(Guid id);
}
