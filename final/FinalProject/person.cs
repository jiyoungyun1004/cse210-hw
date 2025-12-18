using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; }
    public string UserId { get; }
    public DateTime DateOfBirth { get; }

    public SafetyPlan SafetyPlan { get; private set; }

    private readonly List<SymptomEntry> _symptomHistory;

    public Person(string name, string userId, DateTime dateOfBirth)
    {
        Name = name;
        UserId = userId;
        DateOfBirth = dateOfBirth;

        _symptomHistory = new List<SymptomEntry>();
    }

    public int GetAge()
    {
        int age = DateTime.Now.Year - DateOfBirth.Year;

        if (DateTime.Now < DateOfBirth.AddYears(age))
        {
            age--;
        }

        return age;
    }

    public void SetSafetyPlan(SafetyPlan safetyPlan)
    {
        SafetyPlan = safetyPlan;
    }

    public void AddSymptomEntry(SymptomEntry entry)
    {
        if (entry == null)
        {
            return;
        }

        _symptomHistory.Add(entry);
    }

    public IReadOnlyList<SymptomEntry> GetSymptomHistory()
    {
        return _symptomHistory;
    }

    public void DisplayPersonInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"User ID: {UserId}");
        Console.WriteLine($"Age: {GetAge()}");
    }
}
