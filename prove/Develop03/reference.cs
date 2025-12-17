public class Reference
{
    private string book;
    private int chapter;
    private int verse;
    private int endVerse;

    // Single verse reference
    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
        endVerse = verse;
    }

    // Verse range reference
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        verse = startVerse;
        this.endVerse = endVerse;
    }

    public string ToDisplayString()
    {
        if (verse == endVerse)
        {
            return $"{book} {chapter}:{verse}";
        }

        return $"{book} {chapter}:{verse}-{endVerse}";
    }
}
