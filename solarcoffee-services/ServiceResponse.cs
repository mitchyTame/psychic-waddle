namespace solarcoffee_services;

public class ServiceResponse<T>
{
    public bool isSuccess { get; set; }
    public string Message { get; set; }
    public DateTime Time { get; set; }
    public int Status { get; set; }
    public T Data { get; set;  }
}