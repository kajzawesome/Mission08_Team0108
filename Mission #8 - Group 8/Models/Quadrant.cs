namespace Mission__8___Group_8.Models;

public class Quadrant
{
    public int QuadrantId { get; set; }
    public string QuadrantName { get; set; }
    
    public ICollection<System.Threading.Tasks.Task> Tasks { get; set; }
}