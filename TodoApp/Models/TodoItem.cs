namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
