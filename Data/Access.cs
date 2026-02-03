using System.Text.Json;
public static class Access
{
    private static string filePath = "Todos.Json";
    public static void SaveTasks()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(TodoManager.Tasks, options);
        File.WriteAllText(filePath, json);
    }

    public static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            TodoManager.Tasks = JsonSerializer.Deserialize<List<TodoTask>>(json);
        }
    }
}