public static class TodoManger
{
    public static List<TodoTask> Tasks = new();

    public static TodoTask CreatingTask(string title, string description, bool isCompleted, DateTime createdDate)
    {
        int Id = Tasks.Count + 1;
        string Date = createdDate.ToString("dd/mm/yyyy");
        TodoTask Task = new(Id, title, description, isCompleted, Date);
        return Task;

    }
    public static void AddTask(TodoTask task)
    {
        Tasks.Add(task);
    }

    public static bool RemoveTask(TodoTask task)
    {
        if (Tasks is null || Tasks.Count == 0)
        {
            return false;
        }

        if (!Tasks.Contains(task))
        {
            return false;
        }

        Tasks.Remove(task);
        return true;
    }

    public static void CompleteTask(TodoTask task)
    {
        if (!Tasks.Contains(task))
        {
            return;
        }

        if (task.IsCompleted)
        {
            return;
        }

        foreach (TodoTask t in Tasks)
        {
            if (t.Id == task.Id)
            {
                t.IsCompleted = true;
            }
        }
    }

    public static TodoTask GetTask(int id)
    {
        if (Tasks is null || Tasks.Count == 0)
        {
            return null!;
        }

        return Tasks[id - 1];
    }
}