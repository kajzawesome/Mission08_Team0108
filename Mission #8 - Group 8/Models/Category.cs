using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Mission__8___Group_8.Models;

[PrimaryKey(nameof(CategoryId))]

public class Category
{
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string CategoryName { get; set; } = string.Empty;
    
    public ICollection<TaskItem>? Tasks { get; set; }
}