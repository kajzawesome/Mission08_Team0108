namespace Mission__8___Group_8.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    public ICollection<System.Threading.Tasks.Task> Tasks { get; set; }
    
    //Option should be Home, School, Work, Church while building the html
}