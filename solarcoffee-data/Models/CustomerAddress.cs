using System.ComponentModel.DataAnnotations;

namespace solarcoffee_data.Models;

public class CustomerAddress
{
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }

    [MaxLength(100)]
    public string AddressLine1 { get; set; }
    [MaxLength(100)]
    public string AddressLine2 { get; set; }
    [MaxLength(100)]
    public string City { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
    [MaxLength(10)]
    public int PostalCode { get; set; }
    [MaxLength(50)]
    public string Country { get; set; } 
    
    //Navigation Property
    
    
}