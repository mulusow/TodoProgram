public static class TodoScreen
{
    public static void Start()
    {
        int choice = 0;

        while (choice != 5)
        {
            Console.Clear();
            Console.WriteLine("=== Todo List ===");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            string userInput = Console.ReadLine()!.Trim();

            if (!int.TryParse(userInput, out choice))
            {
                Console.WriteLine("Invalid Input. Try Again");
                Console.ReadLine();
                continue;
            }

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
        Console.Clear();

        TodoTask Task = CreateTask();
        TodoManger.AddTask(Task);
        Console.WriteLine("Succesfully Added Task");
        Console.ReadLine();

        return;
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

        ListTaks();
        TodoTask Task = SelectTask();

        if (Task is null)
        {
            Console.WriteLine("No Tasks");
            Console.ReadLine();
            return;
        }

        TodoManger.CompleteTask(Task);
        Console.WriteLine("Succesfully Completed Task");
        return;

    }
    public static void RemoveTask()
    {
        Console.Clear();

        ListTaks();
        TodoTask Task = SelectTask();

        if (Task is null)
        {
            Console.WriteLine("No Tasks");
            Console.ReadLine();
            return;
        }

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
        Console.Clear();

        ListTaks();
        TodoTask Task = SelectTask();

        if (Task is null)
        {
            Console.WriteLine("No Tasks");
            Console.ReadLine();
            return;
        }

        Console.Clear();
        Console.WriteLine(Task.ToString());
        Console.ReadLine();
        return;
    }

    public static void ListTaks()
    {
        if (TodoManger.Tasks.Count == 0)
        {
            Console.WriteLine("No Tasks Found. Create one at 'Add Task'");
        }

        for (int index = 0; index < TodoManger.Tasks.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {TodoManger.Tasks[index].Title}");
        }
    }

    public static TodoTask SelectTask()
    {
        Console.WriteLine("Input Task: ");
        string choice = Console.ReadLine()!.Trim();
        int index;

        while (!int.TryParse(choice, out index))
        {
            Console.WriteLine("Invalid Input. Try Again");
            choice = Console.ReadLine()!.Trim();
        }

        TodoTask Task = TodoManger.GetTask(index - 1);

        return Task;
    }
}