using System;
using System.Collections.Generic;

public class LowCrisisProtocol : InterventionProtocol
{
    public LowCrisisProtocol(
        string protocolId,
        string name,
        CrisisLevel crisisLevel)
        : base(protocolId, name, crisisLevel)
    {
    }

    public override IReadOnlyList<string> GetSteps()
    {
        Steps.Clear();

        Steps.Add("Maintain regular self-care routines.");
        Steps.Add("Keep a consistent schedule for sleep, meals, and activity.");
        Steps.Add("Use preventive coping strategies as needed.");
        Steps.Add("Stay connected with supportive friends or family.");
        Steps.Add("Monitor mood and early warning signs.");
        Steps.Add("Continue with scheduled therapy or support appointments.");
        Steps.Add("Engage in activities that are relaxing or enjoyable.");
        Steps.Add("If symptoms increase, move to a higher level of support.");

        return Steps;
    }

    public override void ExecuteProtocol()
    {
        Console.WriteLine("SELF-CARE AND MONITORING PROTOCOL");
        Console.WriteLine("--------------------------------");

        base.ExecuteProtocol();
        SuggestSelfCare();
    }

    private void SuggestSelfCare()
    {
        Console.WriteLine();
        Console.WriteLine("Self-care reminders:");
        Console.WriteLine("- Spend some time outside.");
        Console.WriteLine("- Practice mindfulness or relaxation.");
        Console.WriteLine("- Connect with someone you trust.");
        Console.WriteLine("- Make time for a hobby or interest.");
        Console.WriteLine("- Get adequate rest and eat regular meals.");
    }
}
