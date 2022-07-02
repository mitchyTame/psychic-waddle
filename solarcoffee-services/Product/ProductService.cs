using System.Data.Common;
using solarcoffee_data;
using solarcoffee_data.Models;

namespace solarcoffee_services.Product;

public class ProductService : IProductService
{
    private SolarDbContext _db;

    public ProductService(SolarDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// Get all the products available from the DB
    /// </summary>
    /// <returns>List of type Data.Models.Product</returns>
    public List<solarcoffee_data.Models.Product> GetAllProducts()
    {
        return _db.Products.ToList();
    }

    /// <summary>
    /// Retrieve a product by it's ID.
    /// </summary>
    /// <param name="id">Int value</param>
    /// <returns>solarcoffee_data.Models.Product</returns>
    public solarcoffee_data.Models.Product GetProductById(int id)
    {
        return _db.Products.Find(id);
    }

    /// <summary>
    /// Adds a new product to the database
    /// </summary>
    /// <param name="product">Data.Models.Product</param>
    /// <returns>ServiceResponse of type Data.Models.Product</returns>
    /// <exception cref="DbException"></exception>
    public ServiceResponse<solarcoffee_data.Models.Product> CreateProduct(solarcoffee_data.Models.Product product)
    {
        try
        {
            _db.Products.Add(product);
            var inventory = new ProductInventory()
            {
                Product = product,
                QuantityOnHand = 0,
                IdealQuantity = 10
            };

            _db.ProductInventories.Add(inventory);

            _db.SaveChanges();

            return new ServiceResponse<solarcoffee_data.Models.Product>
            {
                Data = product,
                Time = DateTime.UtcNow,
                Message = "Saved new product",
                isSuccess = true
            };
        }
        catch (DbException error)
        {

            return new ServiceResponse<solarcoffee_data.Models.Product>
            {
                Data = product,
                Time = DateTime.UtcNow,
                Message = "An error occurred with saving this product",
                isSuccess = false
            };
        }
    }

    /// <summary>
    /// Archive a product in the database. None of the products will be directly deleted from the DB. Setting the isArchived to true. 
    /// </summary>
    /// <param name="id">Integer</param>
    /// <returns>Service response of type Data.Models.Product</returns>
    /// <exception cref="NotImplementedException"></exception>
    public ServiceResponse<solarcoffee_data.Models.Product> ArchiveById(int id)
    {
        var archiveProductById = new solarcoffee_data.Models.Product();
        try
        {
            archiveProductById = _db.Products.Find(id) ?? throw new NullReferenceException("Product was not found");
            archiveProductById.IsArchived = true;
            _db.SaveChanges();

            return new ServiceResponse<solarcoffee_data.Models.Product>
            {
                isSuccess = true,
                Message = $"Product has been successfully archived",
                Time = DateTime.UtcNow,
                Status = 200,
                Data = archiveProductById
            };
        }
        catch (NullReferenceException)
        {
            return new ServiceResponse<solarcoffee_data.Models.Product>
            {
                isSuccess = false,
                Message = $"Product with the particular id could not be found",
                Time = DateTime.UtcNow,
                Status = 404,
                Data = null
            };
        }
        catch (DbException)
        {
            return new ServiceResponse<solarcoffee_data.Models.Product>
            {
                isSuccess = false,
                Message = "There was an issue archiving the product",
                Time = DateTime.UtcNow,
                Status = 500,
                Data = archiveProductById
            };
        }
    }
}