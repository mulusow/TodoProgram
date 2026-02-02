public static class TodoScreen
{
    public static void Start()
    {
        Console.WriteLine("=== Todo List ===");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Complete Task");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Exit");

        string userInput = Console.ReadLine()!.Trim();
        int choice;

        if (!int.TryParse(userInput, out choice))
        {
            Console.WriteLine("Invalid Input. Try Again");
            userInput = Console.ReadLine()!.Trim();
        }

        while (choice != 5)
        {
            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ViewTask();
                    break;
                case 3:
                    CompleteTask();
                    break;
                case 4:
                    RemoveTask();
                    break;
                default:
                    break;
            }
        }
    }

    public static void AddTask()
    {
        TodoTask Task = CreateTask();
        TodoManger.AddTask(Task);

    }
    public static TodoTask CreateTask()
    {
        Console.Write("Title: ");
        string Title = Console.ReadLine()!.Trim();

        if (Title is null || Title == " ")
        {
            Console.WriteLine("Input cannot be Null. Try again");
            Title = Console.ReadLine()!.Trim();
        }

        Console.Write("Description: ");
        string Description = Console.ReadLine()!.Trim();

        if (Description is null || Description == " ")
        {
            Console.WriteLine("Input cannot be Null. Try again");
            Description = Console.ReadLine()!.Trim();
        }

        bool IsCompleted = false;
        DateTime CreatedDate = DateTime.Now;

        TodoTask Task = TodoManger.CreatingTask(Title, Description, IsCompleted, CreatedDate);
        return Task;

    }

    public static void CompleteTask()
    {
        ListTaks();
        TodoTask Task = SelectTask();

        TodoManger.CompleteTask(Task);
        return;

    }
    public static void RemoveTask()
    {
        ListTaks();
        TodoTask Task = SelectTask();

        if (TodoManger.RemoveTask(Task))
        {
            Console.WriteLine("Succesfully Removed Task.");
            Console.ReadLine();
            return;
        }
        else
        {
            Console.WriteLine("Task Not Found.");
            Console.ReadLine();
            return;
        }
    }
    public static void ViewTask()
    {
        ListTaks();
        TodoTask Task = SelectTask();

        Console.WriteLine(Task.ToString());
        Console.ReadLine();
        return;
    }

    public static void ListTaks()
    {
        foreach (TodoTask task in TodoManger.Tasks)
        {
            Console.WriteLine($"{task.Id}. {task.Title}");
        }
    }

    public static TodoTask SelectTask()
    {
        Console.WriteLine("Input Task ID: ");
        string choice = Console.ReadLine()!.Trim();
        int taskId;

        if (!int.TryParse(choice, out taskId))
        {
            Console.WriteLine("Invalid Input. Try Again");
            choice = Console.ReadLine()!.Trim();
        }

        TodoTask Task = TodoManger.GetTask(taskId);

        return Task;
    }
}