namespace solarcoffee_services.Customer;

public class CustomerService : ICustomerService
{
    public List<solarcoffee_data.Models.Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<solarcoffee_data.Models.Customer> CreateCustomer(solarcoffee_data.Models.Customer customer)
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<solarcoffee_data.Models.Customer> UpdateCustomer(solarcoffee_data.Models.Customer customer)
    {
        throw new NotImplementedException();
    }

    public solarcoffee_data.Models.Customer GetCustomerById(int id)
    {
        throw new NotImplementedException();
    }

    public ServiceResponse<bool> ArchiveCustomerById(int id)
    {
        throw new NotImplementedException();
    }
}