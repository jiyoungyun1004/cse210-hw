using System;

public class CrisisResource
{
    public string ResourceId { get; }
    public string Name { get; }
    public string Type { get; }
    public string ContactInfo { get; }
    public string Description { get; }
    public string AvailabilityHours { get; }

    public CrisisResource(
        string resourceId,
        string name,
        string type,
        string contactInfo,
        string description,
        string availabilityHours)
    {
        ResourceId = resourceId;
        Name = name;
        Type = type;
        ContactInfo = contactInfo;
        Description = description;
        AvailabilityHours = availabilityHours;
    }

    public bool IsAvailableNow()
    {
        // Simplified check for demo purposes
        return AvailabilityHours.Contains("24/7") ||
               AvailabilityHours.Contains("24 hours");
    }

    public void DisplayResource()
    {
        Console.WriteLine($"- {Name} ({Type})");
        Console.WriteLine($"  Contact: {ContactInfo}");
        Console.WriteLine($"  Description: {Description}");
        Console.WriteLine($"  Available: {AvailabilityHours}");
    }
}
