using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using solarcoffee_data;
using solarcoffee_data.Models;

namespace solarcoffee_services.Customer;

public class CustomerService : ICustomerService
{
    private readonly SolarDbContext _db;

    public CustomerService(SolarDbContext dbContext)
    {
        _db = dbContext;
    }

    /// <summary>
    /// Retrieves the customers from the database
    /// </summary>
    /// <returns>List of Customer</returns>
    public List<solarcoffee_data.Models.Customer> GetAllCustomers()
    {
        return _db.Customers
            .Include(customer => customer.CustomerAddress)
            .OrderBy(customer => customer.LastName).ToList();
    }

    /// <summary>
    /// Create a specific customer by Customer
    /// </summary>
    /// <param name="customer">Customer instance</param>
    /// <returns>A ServiceResponse of type Customer</returns>
    public ServiceResponse<solarcoffee_data.Models.Customer> CreateCustomer(solarcoffee_data.Models.Customer customer)
    {
        try
        {
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return new ServiceResponse<solarcoffee_data.Models.Customer>
            {
                isSuccess = true,
                Message = "New Customer Added",
                Time = DateTime.UtcNow,
                Data = customer

            };
        }
        catch (DbException e)
        {
            return new ServiceResponse<solarcoffee_data.Models.Customer>
            {
                isSuccess = false,
                Message = e.StackTrace ?? "An error occurred while adding the customer",
                Time = DateTime.UtcNow,
                Data = customer
            };
        }
    }
/// <summary>
/// Update the Customer Details in the Database.
/// Update First Name and Last Name only.
/// </summary>
/// <param name="customer">Instance of Customer</param>
/// <param name="id">Instance of Customer</param>
/// <returns>ServiceResponse of type Customer</returns>
public ServiceResponse<solarcoffee_data.Models.Customer> UpdateCustomer(int id, solarcoffee_data.Models.Customer customer)
{
    solarcoffee_data.Models.Customer updateCustomer = new solarcoffee_data.Models.Customer();
    
    try {
        
        updateCustomer = _db.Customers.Find(id);
        updateCustomer.Name = customer.Name;
        updateCustomer.LastName = customer.LastName;
        _db.Customers.Update(updateCustomer);
        _db.SaveChanges();

        return new ServiceResponse<solarcoffee_data.Models.Customer>
        {
            isSuccess = true,
            Time = DateTime.UtcNow,
            Message = "Successfully updated the customer",
            Data = updateCustomer

        };
    }
    catch (NullReferenceException e)
    {
        return new ServiceResponse<solarcoffee_data.Models.Customer>
        {
            isSuccess = true,
            Time = DateTime.UtcNow,
            Message = "Successfully updated the customer",
            Data = updateCustomer

        };
    }
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