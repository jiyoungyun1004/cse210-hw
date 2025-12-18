using System;

public class SupportContact
{
    public string ContactId { get; }
    public string Name { get; }
    public string PhoneNumber { get; }
    public string Relationship { get; }

    public bool IsAvailable { get; private set; }

    public SupportContact(
        string contactId,
        string name,
        string phoneNumber,
        string relationship,
        bool isAvailable)
    {
        ContactId = contactId;
        Name = name;
        PhoneNumber = phoneNumber;
        Relationship = relationship;
        IsAvailable = isAvailable;
    }

    public void SetAvailability(bool available)
    {
        IsAvailable = available;
    }

    public virtual string GetContactInfo()
    {
        return $"{Name} - {Relationship}: {PhoneNumber}";
    }

    public virtual void DisplayContact()
    {
        Console.WriteLine($"Contact: {Name}");
        Console.WriteLine($"Relationship: {Relationship}");
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
    }
}
