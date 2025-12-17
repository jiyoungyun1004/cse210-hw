public class Goal
{
    // Core goal data
    protected string Name { get; }
    protected string Description { get; }
    protected int Points { get; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    // These are meant to be overridden by specific goal types
    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    // Used for saving/loading goals
    public virtual string GetStringRepresentation()
    {
        return string.Empty;
    }

    // Simple accessors
    public string GetName()
    {
        return Name;
    }

    public int GetPoints()
    {
        return Points;
    }
}
