using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text =
            "Trust in the Lord with all thine heart and lean not unto thine own understanding; " +
            "in all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        string input = "";

        while (input.ToLower() != "quit" && !scripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.Render());
            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");

            input = Console.ReadLine();

            if (input.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        if (scripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.Render());
            Console.WriteLine();
            Console.WriteLine("All words are hidden!");
        }
    }
}
