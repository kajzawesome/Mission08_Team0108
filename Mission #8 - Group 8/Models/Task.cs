using System.ComponentModel.DataAnnotations;

namespace Mission__8___Group_8.Models;

public class Task
{
    public int TaskId { get; set; }
    
    [Required]
    public string TaskName { get; set; }
    
    public DateTime? DueDate { get; set; }
    
    [Required]
    public int QuadrantId { get; set; }
    public Quadrant Quadrant { get; set; }
    
    public int? CategoryID { get; set; }
    public Category Category { get; set; }

    public bool Completed { get; set; } = false;

}