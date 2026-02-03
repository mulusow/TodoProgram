public static class TodoScreen
{
    public static void Start()
    {
        // int choice = 0;

        // while (choice != 5)
        // {
        //     Console.Clear();
        //     Console.WriteLine("=== Todo List ===");
        //     Console.WriteLine("1. Add Task");
        //     Console.WriteLine("2. View Tasks");
        //     Console.WriteLine("3. Complete Task");
        //     Console.WriteLine("4. Delete Task");
        //     Console.WriteLine("5. Exit");

        //     string userInput = Console.ReadLine()!.Trim();

        //     if (!int.TryParse(userInput, out choice))
        //     {
        //         Console.WriteLine("Invalid Input. Try Again");
        //         Console.ReadLine();
        //         continue;
        //     }

        //     switch (choice)
        //     {
        //         case 1:
        //             AddTask();
        //             break;
        //         case 2:
        //             ViewTask();
        //             break;
        //         case 3:
        //             CompleteTask();
        //             break;
        //         case 4:
        //             RemoveTask();
        //             break;
        //         default:
        //             break;
        //     }
        // }

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
        TodoManger.AddTask(Task);
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

        TodoTask Task = TodoManger.CreatingTask(Title, Description, IsCompleted, CreatedDate);
        return Task;

    }

    public static void CompleteTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks";
        string[] TaskOptions = TodoManger.CreateTaskArray();

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

        TodoTask Task = TodoManger.GetTask(SelectedTask);

        TodoManger.CompleteTask(Task);
        Console.WriteLine("Succesfully Completed Task");
        Console.Write("\nPress any key to return to the menu.");
        Console.ReadKey(true);
        Start();

    }
    public static void RemoveTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks";
        string[] TaskOptions = TodoManger.CreateTaskArray();

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

        TodoTask Task = TodoManger.GetTask(SelectedTask);


        if (TodoManger.RemoveTask(Task))
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
        string[] TaskOptions = TodoManger.CreateTaskArray();

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

        TodoTask Task = TodoManger.GetTask(SelectedTask);


        Console.Clear();
        Console.WriteLine(Task.ToString());
        Console.Write("\nPress any key to return to the menu.");
        Console.ReadKey(true);
        Start();
    }

}