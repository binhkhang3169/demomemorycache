using MemoryCaching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCaching.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IMemoryCache _cache;

    public ProductController(AppDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public IActionResult Index()
    {
        const string cacheKey = "productList";
        if (!_cache.TryGetValue(cacheKey, out List<Product> products))
        {
            products = _context.Products.ToList();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));

            _cache.Set(cacheKey, products, cacheEntryOptions);
        }

        return View(products);
    }
}