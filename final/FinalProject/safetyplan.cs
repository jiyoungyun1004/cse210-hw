using System;
using System.Collections.Generic;
using System.Linq;

public class SafetyPlan
{
    public string PlanId { get; }
    public DateTime CreatedDate { get; }
    public DateTime LastUpdated { get; private set; }

    private readonly List<WarningSign> _warningSigns;
    private readonly List<CopingStrategy> _copingStrategies;
    private readonly List<string> _reasonsForLiving;
    private readonly List<SupportContact> _supportContacts;

    public CrisisLevel CurrentCrisisLevel { get; private set; }

    public SafetyPlan()
    {
        PlanId = Guid.NewGuid().ToString();
        CreatedDate = DateTime.Now;
        LastUpdated = CreatedDate;

        _warningSigns = new List<WarningSign>();
        _copingStrategies = new List<CopingStrategy>();
        _reasonsForLiving = new List<string>();
        _supportContacts = new List<SupportContact>();
    }

    public void AddWarningSign(WarningSign warningSign)
    {
        if (warningSign == null) return;

        _warningSigns.Add(warningSign);
        UpdateTimestamp();
    }

    public void AddCopingStrategy(CopingStrategy strategy)
    {
        if (strategy == null) return;

        _copingStrategies.Add(strategy);
        UpdateTimestamp();
    }

    public void AddReasonForLiving(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason)) return;

        _reasonsForLiving.Add(reason);
        UpdateTimestamp();
    }

    public void AddSupportContact(SupportContact contact)
    {
        if (contact == null) return;

        _supportContacts.Add(contact);
        UpdateTimestamp();
    }

    public IReadOnlyList<WarningSign> GetWarningSigns()
    {
        return _warningSigns;
    }

    public IReadOnlyList<CopingStrategy> GetCopingStrategies()
    {
        return _copingStrategies;
    }

    public IReadOnlyList<SupportContact> GetSupportContacts()
    {
        return _supportContacts;
    }

    public void UpdateCrisisLevel(CrisisLevel level)
    {
        CurrentCrisisLevel = level;
        UpdateTimestamp();
    }

    public IReadOnlyList<EmergencyContact> GetEmergencyContacts()
    {
        return _supportContacts.OfType<EmergencyContact>().ToList();
    }

    public void DisplaySafetyPlan()
    {
        Console.WriteLine($"Safety Plan ID: {PlanId}");
        Console.WriteLine($"Last Updated: {LastUpdated}");

        Console.WriteLine("\nWarning Signs:");
        foreach (var sign in _warningSigns)
        {
            sign.DisplayWarningSign();
        }

        Console.WriteLine("\nCoping Strategies:");
        foreach (var strategy in _copingStrategies)
        {
            strategy.DisplayStrategy();
        }

        Console.WriteLine("\nReasons for Living:");
        foreach (var reason in _reasonsForLiving)
        {
            Console.WriteLine($"- {reason}");
        }

        Console.WriteLine("\nSupport Contacts:");
        foreach (var contact in _supportContacts)
        {
            Console.WriteLine($"- {contact.Name} ({contact.Relationship}): {contact.PhoneNumber}");

        }
    }

    private void UpdateTimestamp()
    {
        LastUpdated = DateTime.Now;
    }
}
