namespace API.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Image { get; set; }
    public ProductProperties ProductProperties { get; set; }
}