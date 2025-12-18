using System;

public class TherapistContact : SupportContact
{
    public string OfficeAddress { get; }
    public string Specialty { get; }
    public DateTime NextAppointment { get; }

    public TherapistContact(
        string contactId,
        string name,
        string phoneNumber,
        string relationship,
        bool isAvailable,
        string officeAddress,
        string specialty,
        DateTime nextAppointment)
        : base(contactId, name, phoneNumber, relationship, isAvailable)
    {
        OfficeAddress = officeAddress;
        Specialty = specialty;
        NextAppointment = nextAppointment;
    }

    public override string GetContactInfo()
    {
        return $"[THERAPIST] {Name} - {Specialty}: {PhoneNumber} (Office: {OfficeAddress})";
    }

    public override void DisplayContact()
    {
        Console.WriteLine("=== THERAPIST CONTACT ===");
        Console.WriteLine($"Therapist: {Name}");
        Console.WriteLine($"Specialty: {Specialty}");
        Console.WriteLine($"Phone: {PhoneNumber}");
        Console.WriteLine($"Office Address: {OfficeAddress}");
        Console.WriteLine($"Next Appointment: {NextAppointment.ToShortDateString()}");
        Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
    }
}
