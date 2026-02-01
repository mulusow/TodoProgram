public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public string CreatedDate { get; set; }

    public Task(string title, string description, bool isCompleted, string createdDate)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        CreatedDate = createdDate;
    }

    public Task(int id, string title, string description, bool isCompleted, string createdDate) : this(title, description, isCompleted, createdDate)
    {
        Id = id;
    }

}