namespace WebApplication1.Models
{
    public class ToDoItem
    {
        public ToDoItem(int id, params string[] tasks)
        {
            Id = id;
            Tasks = new List<string>(tasks);
        }

        public int Id { get; }
        public bool IsComplete => Tasks.Count == 0;
        public List<string> Tasks { get; }
    }
}
