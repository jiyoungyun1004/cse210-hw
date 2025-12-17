using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");

                string response = Console.ReadLine();

                // Input validation
                if (string.IsNullOrWhiteSpace(response))
                {
                    Console.WriteLine("Entry cannot be empty. Please try again.\n");
                    continue;
                }

                Console.Write("How are you feeling today (1-10)? ");
                string mood = Console.ReadLine();

                Entry entry = new Entry
                {
                    Date = DateTime.Now.ToShortDateString(),
                    Prompt = prompt,
                    Text = response,
                    Mood = mood
                };

                journal.AddEntry(entry);
                Console.WriteLine("Entry added.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
                Console.WriteLine($"Total entries: {journal.GetEntryCount()}\n");
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to load: ");
                string fileName = Console.ReadLine();

                try
                {
                    journal.LoadFromFile(fileName);
                }
                catch
                {
                    Console.WriteLine("Error loading file.\n");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save: ");
                string fileName = Console.ReadLine();

                try
                {
                    journal.SaveToFile(fileName);
                }
                catch
                {
                    Console.WriteLine("Error saving file.\n");
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.\n");
            }
        }
    }
}

