using solarcoffee_data.Models;
using solarcoffee_services;

namespace solarcoffee_services.Inventory;

public interface sIInventoryService
{
    List<solarcoffee_data.Models.ProductInventory> GetAllProductInventories();
    
    ServiceResponse<solarcoffee_data.Models.ProductInventory> CreateProductInventory(
        solarcoffee_data.Models.ProductInventory inventory);

    ServiceResponse<bool> ArchiveProductInventoryById(int id);

    ServiceResponse<solarcoffee_data.Models.ProductInventory> UpdateProductInventory(
        solarcoffee_data.Models.ProductInventory inventory);
}