namespace Mission__8___Group_8.Models;

//Set up connection data action 
public class EFTaskRepository : ITaskRepository
{
    private AppDbContext _context;
    
    public EFTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<TaskItem> GetTasks()
    {
        return _context.Tasks.ToList();
    }

    public TaskItem? GetTaskById(int id)
    {
        return _context.Tasks
            .SingleOrDefault(x => x.TaskId == id);
    }

    public List<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public List<Quadrant> GetQuadrants()
    {
        return _context.Quadrants.ToList();
    }

    public void AddTask(TaskItem task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(TaskItem task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(int id)
    {
        var record = GetTaskById(id);
        if (record != null)
        {
            _context.Tasks.Remove(record);
            _context.SaveChanges();
        }
    }

    public void MarkComplete(int id)
    {
        var task = _context.Tasks
            .SingleOrDefault(x => x.TaskId == id);

        if (task != null)
        {
            task.Completed = true;
            _context.SaveChanges();
        }
    }
}