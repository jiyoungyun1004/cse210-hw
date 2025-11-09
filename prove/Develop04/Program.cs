using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    
    public static readonly Random rand = new Random();

    static void Main()
    {
        var logger = new ActivityLogger();
        logger.LoadFromFile();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Menu ===");
            Console.WriteLine("1) Breathing");
            Console.WriteLine("2) Reflection");
            Console.WriteLine("3) Listing");
            Console.WriteLine("4) Gratitude");
            Console.WriteLine("5) Show Log");
            Console.WriteLine("6) Quit");
            Console.Write("\nYour choice: ");
            string input = Console.ReadLine();

            Activity act = null;

            switch (input)
            {
                case "1": act = new BreathingActivity(); break;
                case "2": act = new ReflectionActivity();   break;
                case "3": act = new ListingActivity();      break;
                case "4": act = new GratitudeActivity();    break;
                case "5":
                    logger.ShowLog();
                    continue;
                case "6":
                    logger.SaveToFile();
                    return;
                default:
                    Console.WriteLine("Huh? Try again.");
                    Thread.Sleep(1200);
                    continue;
            }

            act.Run();
            logger.Record(act.GetType().Name);
        }
    }
}

// Base class 

abstract class Activity
{
    protected string name;
    protected string description;
    protected int duration;   // seconds

    public Activity(string n, string d)
    {
        name = n;
        description = d;
    }

    public void Run()
    {
        ShowIntro();
        DoTheThing();
        ShowOutro();
    }

    private void ShowIntro()
    {
        Console.Clear();
        Console.WriteLine($"--- {name} ---");
        Console.WriteLine(description);
        Console.Write("\nHow many seconds? ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out duration) && duration > 0) break;
            Console.Write("Enter a positive number: ");
        }

        Console.WriteLine("\nGet ready...");
        Spin(3);               // give them a moment
    }

    private void ShowOutro()
    {
        Console.WriteLine("\nNice work!!");
        Spin(2);
        Console.WriteLine($"You just finished the {name} for {duration} seconds.");
        Spin(3);
    }

    protected abstract void DoTheThing();


    protected void Spin(int secs)
    {
        string[] frames = { "|", "/", "-", "\\" };
        DateTime stop = DateTime.Now.AddSeconds(secs);
        while (DateTime.Now < stop)
        {
            foreach (var f in frames)
            {
                Console.Write(f);
                Thread.Sleep(150);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }

    protected void CountDown(int start)
    {
        for (int i = start; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // pick + remove so we don't repeat in the same session
    protected string GrabOne<T>(List<T> list)
    {
        int idx = Program.rand.Next(list.Count);
        T item = list[idx];
        list.RemoveAt(idx);
        return item.ToString();
    }
}  


// Breathing

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void DoTheThing()
    {
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("Breathe in... ");
            CountDown(4);

            Console.Write("Breathe out... ");
            CountDown(6);
        }
    }
}

// Reflection

class ReflectionActivity : Activity
{
    List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    protected override void DoTheThing()
    {
        Console.WriteLine(GrabOne(prompts));
        Spin(4);                 // give them a second to think

        DateTime stop = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < stop && questions.Count > 0)
        {
            Console.WriteLine($"> {GrabOne(questions)}");
            Spin(7);             // longer pause for reflection
        }
    }
}

// Listing

class ListingActivity : Activity
{
    List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void DoTheThing()
    {
        Console.WriteLine(GrabOne(prompts));
        Console.WriteLine("You have a few seconds to think...");
        CountDown(5);

        int count = 0;
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();     // ignore what they type, just count lines
            count++;
        }

        Console.WriteLine($"\nYou entered {count} items.");
    }
}


// Gratitude – extra activity

class GratitudeActivity : Activity
{
    List<string> prompts = new List<string>
    {
        "What are you grateful for in your health?",
        "What relationships are you thankful for?",
        "What small things made you smile today?",
        "What opportunities are you grateful for?"
    };

    public GratitudeActivity()
        : base("Gratitude Activity",
               "List things you are thankful for in a specific area.") { }

    protected override void DoTheThing()
    {
        Console.WriteLine(GrabOne(prompts));
        CountDown(4);

        int cnt = 0;
        DateTime stop = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < stop)
        {
            Console.Write("> ");
            Console.ReadLine();
            cnt++;
        }
        Console.WriteLine($"\nYou listed {cnt} gratitude items.");
    }
}


class ActivityLogger
{
    Dictionary<string, int> stats = new Dictionary<string, int>();
    const string FILE = "Log.txt";

    public void Record(string name)
    {
        if (stats.ContainsKey(name))
            stats[name]++;
        else
            stats[name] = 1;
    }

    public void ShowLog()
    {
        Console.Clear();
        Console.WriteLine("=== Activity Log ===");
        if (stats.Count == 0)
            Console.WriteLine("(nothing yet)");
        else
            foreach (var kv in stats)
                Console.WriteLine($"{kv.Key}: {kv.Value} time(s)");
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public void SaveToFile()
    {
        using (var sw = new StreamWriter(FILE))
        {
            foreach (var kv in stats)
                sw.WriteLine($"{kv.Key},{kv.Value}");
        }
    }

    public void LoadFromFile()
    {
        if (!File.Exists(FILE)) return;

        foreach (string line in File.ReadAllLines(FILE))
        {
            var parts = line.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[1], out int c))
                stats[parts[0]] = c;
        }
    }
}