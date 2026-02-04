using System.Runtime.InteropServices;

public static class TodoScreen
{
    public static void Start()
    {
        string Prompt = "Welcome to this program. Choose your option!";
        string[] Options = { "Add Task", "View Tasks", "Exit" };

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
    public static void ViewTask()
    {
        Console.Clear();

        string Prompt = "Use arrow keys to navigate tasks OR press BACKSPACE to go back.";
        string[] TaskOptions = TodoManager.CreateTaskArray();

        if (TaskOptions.Length == 0)
        {
            Console.WriteLine(Prompt);
            Console.WriteLine("\nNo Tasks Found..");
            Console.ReadKey(true);
            Start();
        }

        Menu TaskMenu = new(Prompt, TaskOptions);
        int SelectedTask = TaskMenu.Run();

        if (SelectedTask == -1)
        {
            Start();
        }

        TodoTask Task = TodoManager.GetTask(SelectedTask);


        EditTask(Task);
        Access.SaveTasks();
        Start();
    }

    public static void EditTask(TodoTask Task)
    {
        string prompt = "\nPress BACKSPACE to return.\n\n" + Task.ToString();
        string[] Options = { "Edit Title", "Edit Description", "Toggle Status", "DELETE" };
        Menu TaskMenu = new(prompt, Options);

        Console.Clear();
        int SelectedOption = TaskMenu.Run();

        switch (SelectedOption)
        {
            case 0:
                Task.Title = EditStringProperty();
                EditTask(Task);
                break;
            case 1:
                Task.Description = EditStringProperty();
                EditTask(Task);
                break;
            case 2:
                Task.IsCompleted = !Task.IsCompleted;
                EditTask(Task);
                break;
            case 3:
                RemoveTask(Task);
                break;
            default:
                Access.SaveTasks();
                ViewTask();
                break;

        }

    }

    public static string EditStringProperty()
    {
        Console.Clear();
        Console.Write("> ");
        string Property = Console.ReadLine()!.Trim();

        while (Property == "")
        {
            Console.Clear();
            Console.WriteLine("Input cannot be Null. Try again\n");
            Console.Write("> ");
            Property = Console.ReadLine()!.Trim();
        }

        return Property;
    }

    public static void RemoveTask(TodoTask Task)
    {
        string prompt = "Are you Sure?";
        string[] Options = { "YES", "NO" };
        Menu TaskMenu = new(prompt, Options);

        int SelectedOption = TaskMenu.Run();

        if (SelectedOption == 0)
        {
            if (TodoManager.RemoveTask(Task))
            {
                Console.Clear();
                Console.WriteLine("Task removed successfully!");
                Console.ReadKey(true);
                Start();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Failed to remove Task!!!");
                Console.ReadKey(true);
                EditTask(Task);
            }
        }
        else
        {
            EditTask(Task);
        }
    }

}