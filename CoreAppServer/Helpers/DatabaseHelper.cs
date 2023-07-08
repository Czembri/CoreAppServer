using API.Data;

namespace API.Helpers;

public static class DatabaseHelper
{
    public static void Add<T>(T newItem, DataContext db) where T : class
    {
        db.Set<T>().Add(newItem);
    }
}