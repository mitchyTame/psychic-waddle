using solarcoffee_data.Models;
using solarcoffee_web.ViewModels;

namespace solarcoffee_web.Serialization;

public class ProductMapper
{
    /// <summary>
    /// Map Data.Model to a View Model
    /// </summary>
    /// <param name="product"></param>
    /// <returns>ProductModel</returns>
    public static ProductModel Serialize_ProductModel(Product product)
    {
        return new ProductModel
        {
            Id = product.Id,
            CreatedOn = product.CreatedOn,
            UpdatedOn = product.UpdatedOn,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            IsTaxable = product.IsTaxable,
            IsArchived = product.IsArchived,
            isDeleted = product.isDeleted,

        };
    }
    /// <summary>
    /// Maps from View Model to a data Product Model
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public static Product Serialize_DataModel(ProductModel product)
    {
        return new Product
        {
            Id = product.Id,
            CreatedOn = product.CreatedOn,
            UpdatedOn = product.UpdatedOn,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            IsTaxable = product.IsTaxable,
            IsArchived = product.IsArchived,
            isDeleted = product.isDeleted,

        };
    }
}