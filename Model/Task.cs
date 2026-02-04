public class TodoTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public string CreatedDate { get; set; }

    public TodoTask()
    {

    }
    public TodoTask(string title, string description, bool isCompleted, string createdDate)
    {
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
        CreatedDate = createdDate;
    }

    public TodoTask(int id, string title, string description, bool isCompleted, string createdDate) : this(title, description, isCompleted, createdDate)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $"ID: {Id}\nTitle: {Title}\nDescription: {Description}\nStatus: {(IsCompleted ? "[✓]" : "[ ]")}\nCreated: {CreatedDate}";
    }

}