using System.Reflection;
using System.Text;
using System.Text.Json;
using API.Entities;
using API.Interfaces;
using Newtonsoft.Json.Linq;

namespace API.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private PropertyInfo[] _productPropertyInfo;
    private PropertyInfo[] _productPropertiesPropertyInfo;
    private const string BaseUrl = "http://localhost:20262";
    private const string ContentType = "application/json";

    public ProductService()
    {
        _httpClient = new HttpClient();
        _productPropertyInfo = typeof(Product).GetProperties();
        _productPropertiesPropertyInfo = typeof(ProductProperty).GetProperties();
    }
    
    public async Task<string> GetProductDescription(Product product)
    {
        const string productDescriptionUrl = BaseUrl + "/Description";

        var productObjectParameter = new List<dynamic>();
        
        foreach (var propertyInfo in _productPropertyInfo)
        {
            if (propertyInfo.Name != nameof(Product.ProductProperty))
            {
                productObjectParameter.Add(new {
                    propertyInfo.Name,
                    Value = propertyInfo.GetValue(product),
                    Description = propertyInfo.Name + " test"
                });
            }
            else
            {
                productObjectParameter.AddRange(
                    _productPropertiesPropertyInfo.Select(p => new
                    {
                        p.Name,
                        Value = p.GetValue(propertyInfo.GetValue(product)),
                        Description = p.Name + " test"
                    }));
            }
        }
        
        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(productObjectParameter), Encoding.UTF8, ContentType);
        var response = await _httpClient.PostAsync(productDescriptionUrl, httpContent);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<byte[]> GetProductImage(string description)
    {
        const string productImageUrl = BaseUrl + "/Image";
        HttpContent httpContent = new StringContent(JsonSerializer.Serialize(new
        {
            description
        }), Encoding.UTF8, ContentType);
        var response = await _httpClient.PostAsync(productImageUrl, httpContent);
        var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
        var stringResult = (string)json["openai"]["items"][0]["image"];
        return Encoding.ASCII.GetBytes(stringResult);
    }
}