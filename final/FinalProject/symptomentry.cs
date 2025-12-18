using System;
using System.Collections.Generic;

public class SymptomEntry
{
    public string EntryId { get; }
    public DateTime Date { get; }
    public string SymptomDescription { get; }
    public int IntensityLevel { get; }

    private readonly List<string> _triggers;

    public SymptomEntry(
        string entryId,
        DateTime date,
        string symptomDescription,
        int intensityLevel)
    {
        EntryId = entryId;
        Date = date;
        SymptomDescription = symptomDescription;
        IntensityLevel = intensityLevel;

        _triggers = new List<string>();
    }

    public void AddTrigger(string trigger)
    {
        if (string.IsNullOrWhiteSpace(trigger))
        {
            return;
        }

        _triggers.Add(trigger);
    }

    public IReadOnlyList<string> GetTriggers()
    {
        return _triggers;
    }

    public string GetIntensityCategory()
    {
        if (IntensityLevel >= 8)
            return "Severe";
        if (IntensityLevel >= 5)
            return "Moderate";
        if (IntensityLevel >= 3)
            return "Mild";

        return "Minimal";
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date.ToShortDateString()}");
        Console.WriteLine($"Symptom: {SymptomDescription}");
        Console.WriteLine($"Intensity: {IntensityLevel}/10 ({GetIntensityCategory()})");

        if (_triggers.Count == 0)
        {
            return;
        }

        Console.WriteLine("Triggers:");
        foreach (var trigger in _triggers)
        {
            Console.WriteLine($"  - {trigger}");
        }
    }
}
