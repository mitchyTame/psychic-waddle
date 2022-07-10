namespace solarcoffee_services.Customer;

public interface ICustomerService
{
    List<solarcoffee_data.Models.Customer> GetAllCustomers();
    ServiceResponse<solarcoffee_data.Models.Customer> CreateCustomer(solarcoffee_data.Models.Customer customer);
    ServiceResponse<solarcoffee_data.Models.Customer> UpdateCustomer(solarcoffee_data.Models.Customer customer);
    solarcoffee_data.Models.Customer GetCustomerById(int id);
    ServiceResponse<bool> ArchiveCustomerById(int id);
}