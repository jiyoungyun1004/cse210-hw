using System;
using System.Collections.Generic;

public class ModerateCrisisProtocol : InterventionProtocol
{
    public ModerateCrisisProtocol(
        string protocolId,
        string name,
        CrisisLevel crisisLevel)
        : base(protocolId, name, crisisLevel)
    {
    }

    public override IReadOnlyList<string> GetSteps()
    {
        Steps.Clear();

        Steps.Add("Pause and acknowledge what you are feeling.");
        Steps.Add("Use a coping strategy from your safety plan, such as deep breathing or grounding.");
        Steps.Add("Reach out to a trusted friend, family member, or support contact.");
        Steps.Add("Review your reasons for living.");
        Steps.Add("Avoid isolating yourself; stay connected to others.");
        Steps.Add("If distress increases, contact a crisis hotline at 988.");
        Steps.Add("Consider scheduling a therapy or support appointment within the next few days.");

        return Steps;
    }

    public override void ExecuteProtocol()
    {
        Console.WriteLine("MODERATE CRISIS MANAGEMENT PROTOCOL");
        Console.WriteLine("----------------------------------");

        base.ExecuteProtocol();
        SuggestNextSteps();
    }

    private void SuggestNextSteps()
    {
        Console.WriteLine();
        Console.WriteLine("Suggestion:");
        Console.WriteLine("Review your safety plan and use coping strategies that have helped you before.");
    }
}
