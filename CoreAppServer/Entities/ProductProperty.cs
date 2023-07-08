namespace API.Entities;

public class ProductProperty
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Product Product { get; set; }
}