public static class TodoScreen
{
    public static void Start()
    {
        Access.LoadTasks();

        string Prompt = "Welcome to this program. Choose your option!";
        string[] Options = { "Add Task", "View Tasks", "Complete Task", "Delete Task", "Exit" };

        Menu MainMenu = new(Prompt, Options);
        int SelectedOption = MainMenu.Run();

        switch (SelectedOption)
        {
            case 0:
                AddTask();
                break;
            case 1:
                ViewTask();
                break;
            case 2:
                CompleteTask();
                break;
            case 3:
                RemoveTask();
                break;
            default:
                Environment.Exit(0);
                break;
        }

    }

    public static void AddTask()
    {
        Console.Clear();

        TodoTask Task = CreateTask();
        TodoManager.AddTask(Task);
        Console.WriteLine("Succesfully Added Task");
        Console.Write("\nPress any key to return to the menu.");
        Console.ReadKey(true);
        Start();
    }
    public static TodoTask CreateTask()
    {
        Console.Write("Title: ");
        string Title = Console.ReadLine()!.Trim();

        while (Title == "")
        {
            Console.WriteLine("Input cannot be Null. Try again");
            Title = Console.ReadLine()!.Trim();
        }

        Console.Write("Description: ");
        string Description = Console.ReadLine()!.Trim();

        while (Description == "")
        {
            Console.WriteLine("Input cannot be Null. Try again");
            Description = Console.ReadLine()!.Trim();
        }

        bool IsCompleted = false;
        DateTime CreatedDate = DateTime.Now;

        TodoTask Task = TodoManager.CreatingTask(Title, Description, IsCompleted, CreatedDate);
        return Task;

    }

    public static void CompleteTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks";
        string[] TaskOptions = TodoManager.CreateTaskArray();

        if (TaskOptions.Length == 0)
        {
            Console.WriteLine(Prompt);
            Console.WriteLine("\nNo Tasks");
            Console.Write("\nPress any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }

        Menu TaskMenu = new(Prompt, TaskOptions);
        int SelectedTask = TaskMenu.Run();

        TodoTask Task = TodoManager.GetTask(SelectedTask);

        TodoManager.CompleteTask(Task);
        Console.WriteLine("Succesfully Completed Task");
        Console.Write("\nPress any key to return to the menu.");
        Console.ReadKey(true);
        Start();

    }
    public static void RemoveTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks";
        string[] TaskOptions = TodoManager.CreateTaskArray();

        if (TaskOptions.Length == 0)
        {
            Console.WriteLine(Prompt);
            Console.WriteLine("\nNo Tasks");
            Console.Write("\nPress any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }

        Menu TaskMenu = new(Prompt, TaskOptions);
        int SelectedTask = TaskMenu.Run();

        TodoTask Task = TodoManager.GetTask(SelectedTask);


        if (TodoManager.RemoveTask(Task))
        {
            Console.WriteLine("Succesfully Removed Task.");
            Console.Write("\nPress any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }
        else
        {
            Console.WriteLine("Task Not Found.");
            Console.Write("\nPress any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }
    }
    public static void ViewTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks";
        string[] TaskOptions = TodoManager.CreateTaskArray();

        if (TaskOptions.Length == 0)
        {
            Console.WriteLine(Prompt);
            Console.WriteLine("\nNo Tasks");
            Console.Write("\nPress any key to return to the menu.");
            Console.ReadKey(true);
            Start();
        }

        Menu TaskMenu = new(Prompt, TaskOptions);
        int SelectedTask = TaskMenu.Run();

        TodoTask Task = TodoManager.GetTask(SelectedTask);


        Console.Clear();
        Console.WriteLine(Task.ToString());
        Console.Write("\nPress any key to return to the menu.");
        Console.ReadKey(true);
        Start();
    }

}