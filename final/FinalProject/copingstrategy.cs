using System;

public class CopingStrategy
{
    public string StrategyId { get; }
    public string Name { get; }
    public string Description { get; }
    public string Category { get; }

    public int EffectivenessRating { get; private set; }

    public CopingStrategy(
        string strategyId,
        string name,
        string description,
        string category,
        int effectivenessRating)
    {
        StrategyId = strategyId;
        Name = name;
        Description = description;
        Category = category;

        SetEffectivenessRating(effectivenessRating);
    }

    public void SetEffectivenessRating(int rating)
    {
        if (rating < 0 || rating > 10)
        {
            return;
        }

        EffectivenessRating = rating;
    }

    public void DisplayStrategy()
    {
        Console.WriteLine($"{Name} (Effectiveness: {EffectivenessRating}/10)");
        Console.WriteLine($"  Description: {Description}");
        Console.WriteLine($"  Category: {Category}");
    }
}
