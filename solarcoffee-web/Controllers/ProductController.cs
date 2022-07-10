using Microsoft.AspNetCore.Mvc;
using solarcoffee_data.Models;
using solarcoffee_services;
using solarcoffee_services.Product;
using solarcoffee_web.Serialization;

namespace solarcoffee_web.Controllers;

[ApiController]
[ApiVersion("1")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet("/api/product")]
    public ActionResult GetProduct()
    {
        _logger.LogInformation("Retrieving all products");
        var products =  _productService.GetAllProducts();
        var productViewModel = products.Select(ProductMapper.Serialize_ProductModel);
        return Ok(productViewModel);
    }

}