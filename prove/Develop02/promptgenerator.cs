public class PromptGenerator
{
    // Stores the available journal prompts
    private List<string> prompts;

    public PromptGenerator()
    {
        prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What challenged me today and how did I respond?"
        };
    }

    // Returns a random prompt from the list
    public string GetRandomPrompt()
    {
        Random rng = new Random();
        int index = rng.Next(prompts.Count);
        return prompts[index];
    }
}
