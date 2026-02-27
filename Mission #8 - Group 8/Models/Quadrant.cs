using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Mission__8___Group_8.Models;

[PrimaryKey(nameof(QuadrantId))]

public class Quadrant
{
    [Required]
    public int QuadrantId { get; set; }
    [Required]
    public string QuadrantName { get; set; } = string.Empty;

    public ICollection<TaskItem>? Tasks { get; set; } = new List<TaskItem>();
}