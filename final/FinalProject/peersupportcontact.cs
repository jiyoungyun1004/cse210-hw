using System;

public class PeerSupportContact : SupportContact
{
    public string PreferredContactMethod { get; }
    public string Notes { get; }

    public PeerSupportContact(
        string contactId,
        string name,
        string phoneNumber,
        string relationship,
        bool isAvailable,
        string preferredContactMethod,
        string notes)
        : base(contactId, name, phoneNumber, relationship, isAvailable)
    {
        PreferredContactMethod = preferredContactMethod;
        Notes = notes;
    }

    public override string GetContactInfo()
    {
        return $"[PEER SUPPORT] {Name} - {Relationship}: {PhoneNumber} (Preferred: {PreferredContactMethod})";
    }

    public override void DisplayContact()
    {
        Console.WriteLine("=== PEER SUPPORT CONTACT ===");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Relationship: {Relationship}");
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Preferred Contact Method: {PreferredContactMethod}");
        Console.WriteLine($"Notes: {Notes}");
        Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
    }
}
