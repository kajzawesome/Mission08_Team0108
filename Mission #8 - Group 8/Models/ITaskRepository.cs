namespace Mission__8___Group_8.Models;

//The template for data connection
public interface ITaskRepository
{
    List<TaskItem> GetTasks();

    TaskItem? GetTaskById(int id);
    List<Category> GetCategories();
    List<Quadrant> GetQuadrants();

    public void AddTask(TaskItem tasks);
    public void UpdateTask(TaskItem tasks);
    public void DeleteTask(int id);
    public void MarkComplete (int id);
}