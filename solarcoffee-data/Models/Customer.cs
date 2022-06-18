namespace solarcoffee_data.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    
    //Navigation Properties
    public CustomerAddress CustomerAddress { get; set; }    
    
}