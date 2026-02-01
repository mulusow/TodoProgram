public static class TodoManger
{
    public static List<Task> Tasks = new();

    public static Task CreatingTask(string title, string description, bool isCompleted, DateTime createdDate)
    {
        int Id = Tasks.Count + 1;
        string Date = createdDate.ToString("dd/mm/yyyy");
        Task Task = new(Id, title, description, isCompleted, Date);
        return Task;

    }
    public static void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public static bool RemoveTask(Task task)
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

    public static void CompleteTask(Task task)
    {
        if (!Tasks.Contains(task))
        {
            return;
        }

        if (task.IsCompleted)
        {
            return;
        }

        foreach (Task t in Tasks)
        {
            if (t.Id == task.Id)
            {
                t.IsCompleted = true;
            }
        }
    }

    public static Task GetTask(int id)
    {
        return Tasks[id];
    }
}