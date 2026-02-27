using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mission__8___Group_8.Models;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }
    
    [Required]
    public string TaskName { get; set; } = string.Empty;
    
    public DateTime? DueDate { get; set; }
    
    [Required]
    public int QuadrantId { get; set; }

    [Required]
    public Quadrant Quadrant { get; set; } = null!;
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public bool Completed { get; set; } = false;

}