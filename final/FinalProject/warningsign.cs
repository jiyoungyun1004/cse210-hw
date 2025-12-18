using System;

public class WarningSign
{
    public string SignId { get; }
    public string Severity { get; }
    public string Category { get; }

    public string Description { get; private set; }

    public WarningSign(string signId, string description, string severity, string category)
    {
        SignId = signId;
        Description = description;
        Severity = severity;
        Category = category;
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return;
        }

        Description = description;
    }

    public void DisplayWarningSign()
    {
        Console.WriteLine($"[{Severity}] {Description} (Category: {Category})");
    }
}
