using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    // Adds an entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Displays all journal entries
    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    // Returns the total number of entries
    public int GetEntryCount()
    {
        return entries.Count;
    }

    // Saves entries to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(
                    $"{entry.Date}~|~{entry.Prompt}~|~{entry.Text}~|~{entry.Mood}"
                );
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    // Loads entries from a file
    public void LoadFromFile(string fileName)
    {
        entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            if (parts.Length != 4)
                continue;

            Entry entry = new Entry
            {
                Date = parts[0],
                Prompt = parts[1],
                Text = parts[2],
                Mood = parts[3]
            };

            entries.Add(entry);
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}

