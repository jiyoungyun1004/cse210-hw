using System;
using System.Collections.Generic;

public class InterventionProtocol
{
    public string ProtocolId { get; }
    public string Name { get; }
    public CrisisLevel CrisisLevel { get; }

    protected readonly List<string> Steps;

    public InterventionProtocol(string protocolId, string name, CrisisLevel crisisLevel)
    {
        ProtocolId = protocolId;
        Name = name;
        CrisisLevel = crisisLevel;

        Steps = new List<string>();
    }

    public virtual IReadOnlyList<string> GetSteps()
    {
        return Steps;
    }

    public virtual void ExecuteProtocol()
    {
        Console.WriteLine($"Protocol: {Name}");
        Console.WriteLine($"Crisis Level: {CrisisLevel.LevelName}");
        Console.WriteLine("\nSteps:");

        var steps = GetSteps();
        for (int i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    public void DisplayProtocol()
    {
        Console.WriteLine($"Protocol ID: {ProtocolId}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Associated Crisis Level: {CrisisLevel.LevelName}");
    }
}

