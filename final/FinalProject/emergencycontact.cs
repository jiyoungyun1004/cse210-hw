using System;

public class EmergencyContact : SupportContact
{
    public string ResponseTime { get; }
    public int Priority { get; }

    public EmergencyContact(
        string contactId,
        string name,
        string phoneNumber,
        string relationship,
        bool isAvailable,
        string responseTime,
        int priority)
        : base(contactId, name, phoneNumber, relationship, isAvailable)
    {
        ResponseTime = responseTime;
        Priority = priority;
    }

    public override string GetContactInfo()
    {
        return $"[EMERGENCY - Priority {Priority}] {Name} - {Relationship}: {PhoneNumber} (Response: {ResponseTime})";
    }

    public override void DisplayContact()
    {
        Console.WriteLine("=== EMERGENCY CONTACT ===");
        Console.WriteLine($"Priority Level: {Priority}");
        Console.WriteLine($"Contact: {Name}");
        Console.WriteLine($"Relationship: {Relationship}");
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Expected Response Time: {ResponseTime}");
        Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
    }
}
