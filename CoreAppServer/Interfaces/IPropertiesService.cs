using API.Data;

namespace API.Interfaces;

public interface IPropertiesService
{
    Task<object> AddObjectProperty<T>(DataContext context, T value) where T : class;
}