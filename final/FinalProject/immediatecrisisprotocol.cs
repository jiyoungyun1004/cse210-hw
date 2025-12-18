using System;
using System.Collections.Generic;

public class ImmediateCrisisProtocol : InterventionProtocol
{
    public string EmergencyServicesNumber { get; }
    public bool RequiresImmediateAction { get; }

    public ImmediateCrisisProtocol(
        string protocolId,
        string name,
        CrisisLevel crisisLevel,
        string emergencyServicesNumber)
        : base(protocolId, name, crisisLevel)
    {
        EmergencyServicesNumber = emergencyServicesNumber;
        RequiresImmediateAction = true;
    }

    public override IReadOnlyList<string> GetSteps()
    {
        Steps.Clear();

        Steps.Add($"Call {EmergencyServicesNumber} immediately if you are in immediate danger.");
        Steps.Add("Call the National Suicide Prevention Lifeline at 988.");
        Steps.Add("Text the Crisis Text Line by texting HOME to 741741.");
        Steps.Add("Go to the nearest emergency room.");
        Steps.Add("Do not remain alone. Contact an emergency support person immediately.");
        Steps.Add("Remove any immediate means of self-harm from your environment if possible.");

        return Steps;
    }

    public override void ExecuteProtocol()
    {
        Console.WriteLine("IMMEDIATE CRISIS PROTOCOL");
        Console.WriteLine("--------------------------");

        base.ExecuteProtocol();
        NotifyEmergencyContacts();
    }

    private void NotifyEmergencyContacts()
    {
        Console.WriteLine();
        Console.WriteLine("Emergency contacts should be notified immediately.");
    }
}
