using Microsoft.EntityFrameworkCore;

namespace Mission__8___Group_8.Models;

//Set up tables
public partial class AppDbContext: DbContext
{
    public AppDbContext()
    {}
    
    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options)
    {}
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Quadrant> Quadrants { get; set; }
}