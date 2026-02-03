public class Menu
{
    private int _selectedIndex;
    private string[] _options { get; }
    private string _prompt;

    public Menu(string prompt, string[] options)
    {
        _options = options;
        _prompt = prompt;
    }

    private void DisplayOptions()
    {
        Console.Clear();
        Console.WriteLine(_prompt);
        Console.WriteLine();

        for (int i = 0; i < _options.Length; i++)
        {
            string CurrentOption = _options[i];
            string prefix;

            if (i == _selectedIndex)
            {
                prefix = ">";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"{prefix} {CurrentOption}");
        }
        Console.ResetColor();
    }

    public int Run()
    {
        ConsoleKey KeyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();

            ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
            KeyPressed = KeyInfo.Key;

            if (KeyPressed == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex == -1)
                {
                    _selectedIndex = 0;
                }
            }
            else if (KeyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;

                if (_selectedIndex == _options.Length)
                {
                    _selectedIndex = _options.Length - 1;
                }

            }
        }
        while (KeyPressed != ConsoleKey.Enter);
        return _selectedIndex;
    }
}