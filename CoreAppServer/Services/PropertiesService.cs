using API.Data;
using API.Helpers;
using API.Interfaces;

namespace API.Services;

public class PropertiesService : IPropertiesService
{
    public async Task<object> AddObjectProperty<T>(DataContext context, T value) where T : class
    {
        DatabaseHelper.Add(value, context);
        await context.SaveChangesAsync();
        return value;
    }
}