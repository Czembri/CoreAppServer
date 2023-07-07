using API.Entities;

namespace API.Interfaces;

public interface IProductService
{
    Task<string> GetProductDescription(Product product);
    Task<byte[]> GetProductImage(string description);
}