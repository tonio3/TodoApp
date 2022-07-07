namespace Todolist
{
    public class TodoItem
    {
        public int Id { get; set; }
        public bool IsDone { get; set; } = false;
        public string Name { get; set; }
        public string User { get; set; }
        public string Importance { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
