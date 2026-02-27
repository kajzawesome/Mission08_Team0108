namespace Mission__8___Group_8.Models;

//The template for data connection
public interface ITaskRepository
{
    List<Task> Tasks { get; }
    List<Category> Categories { get; }
    List<Quadrant> Quadrants { get; }

    public void AddTask(Task tasks);
    public void UpdateTask(Task tasks);
    public void DeleteTask(int id);
    public void MarkComplete (int id);

}