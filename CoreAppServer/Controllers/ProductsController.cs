using System.Buffers.Text;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ProductsController: BaseApiController
{
    private readonly DataContext _context;
    private readonly IProductService _productService;
    private readonly IPropertiesService _propertiesService;

    public ProductsController(DataContext context,
        IProductService productService,
        IPropertiesService propertiesService)
    {
        _context = context;
        _productService = productService;
        _propertiesService = propertiesService;
    }

    [HttpPatch("{id}/Description")]
    public async Task<string> PatchProductDescription(int id)
    {
        var product = await GetAsync(id);
         product.Description = await _productService.GetProductDescription(product);
         await _context.SaveChangesAsync();

         return product.Description;
    }
    
    [HttpPatch("{id}/Image")]
    public async Task<IActionResult> PatchProductImage(int id)
    {
        var product = await GetAsync(id);
        product.Image = await _productService.GetProductImage(product.Description);
        await _context.SaveChangesAsync();

        return File(product.Image, "image/jpg");
    }
    
    [HttpGet]
    public async Task<List<Product>> GetProducts()
    {
        var products = await _context.Product.AsNoTracking()
            .Include(x => x.ProductProperty)
            .ToListAsync();
        return products;
    }

    [HttpGet("{id}")]
    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Product.AsNoTracking()
            .Include(x => x.ProductProperty)
            .FirstOrDefaultAsync(x => x.Id == id);
        return product;
    }
    
    [HttpGet("{id}/Image")]
    public async Task<IActionResult> GetProductImage(int id)
    {
        var product = await _context.Product.AsNoTracking()
            .Where(product => product.Id == id)
            //.Select(product => product.Image)
            .FirstOrDefaultAsync();
        return File(product.Image, "image/jpg", $"image_{id}.jpg?cb={DateTime.Now}");
    }

    [HttpGet("{id}/Image2")]
    public async Task<IActionResult> GetProductImage2(int id)
    {
        var image = await _context.Product.AsNoTracking()
            .Where(product => product.Id == id)
            .Select(product => product.Image)
            .FirstOrDefaultAsync();
        return Ok(Convert.ToBase64String(image));
    }

    [HttpPut("{id}")]
    public async Task<bool> UpdateProduct(int id, [FromBody] Product product)
    {
        var dbObj = await _context.Product
            .Include(x => x.ProductProperty)
            .FirstOrDefaultAsync(x => x.Id == id);
        dbObj.Description = product.Description;
        dbObj.Image = product.Image;

        await _context.SaveChangesAsync();
        return true;
    }

    [HttpPost("{id}/Property")]
    public async Task<IActionResult> AddProductProperty(int id, [FromBody] ProductProperty productProperty)
    {
        var product = await GetAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        productProperty.Product = product;
        var result = await _propertiesService.AddObjectProperty(_context, productProperty);
        return Ok(result);
    }

    private async Task<Product> GetAsync(int id)
    {
        return await _context.Product.Include(x => x.ProductProperty)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}