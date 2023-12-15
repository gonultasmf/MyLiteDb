namespace MyLiteDb.Models;

public class Customer : BaseModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
}
