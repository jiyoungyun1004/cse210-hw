using System;

public class CrisisLevel
{
    public string LevelName { get; }
    public int SeverityScore { get; }
    public string Description { get; }
    public string RecommendedAction { get; }

    public CrisisLevel(
        string levelName,
        int severityScore,
        string description,
        string recommendedAction)
    {
        LevelName = levelName;
        SeverityScore = severityScore;
        Description = description;
        RecommendedAction = recommendedAction;
    }

    public bool RequiresImmediateHelp()
    {
        return SeverityScore >= 8;
    }

    public void DisplayCrisisLevel()
    {
        Console.WriteLine($"Crisis Level: {LevelName} (Severity: {SeverityScore}/10)");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Recommended Action: {RecommendedAction}");

        if (RequiresImmediateHelp())
        {
            Console.WriteLine("Immediate professional help is recommended.");
        }
    }
}
