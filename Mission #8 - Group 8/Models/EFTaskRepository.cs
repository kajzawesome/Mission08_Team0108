namespace Mission__8___Group_8.Models;

//Set up connection data action 
public class EFTaskRepository : ITaskRepository
{
    private AppDbContext _context;
    
    public EFTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Task> Tasks => _context.Tasks.ToList();
    public List<Category> Categories => _context.Categories.ToList();
    public List<Quadrant> Quadrants => _context.Quadrants.ToList();

    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var deleterecord = _context.Tasks
            .Single(x => x.TaskId == id);
        _context.Remove(deleterecord);
        _context.SaveChanges();
    }

    public void MarkComplete(int id)
    {
        var completed = _context.Tasks
            .Single(x => x.TaskId == id);
        completed.Completed = true;
        _context.SaveChanges();

    }
}