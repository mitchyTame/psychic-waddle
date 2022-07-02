using solarcoffee_data.Models;

namespace solarcoffee_services.Product;

public interface IProductService
{
    List<solarcoffee_data.Models.Product> GetAllProducts();
    solarcoffee_data.Models.Product GetProductById(int id);
    ServiceResponse<solarcoffee_data.Models.Product> CreateProduct(solarcoffee_data.Models.Product product);
    ServiceResponse<solarcoffee_data.Models.Product> ArchiveById(int id);
}