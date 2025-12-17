public class Entry
{
    public string Date;
    public string Prompt;
    public string Text;
    public string Mood;

    // Displays a single journal entry
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine(Text);
        Console.WriteLine();
    }
}
