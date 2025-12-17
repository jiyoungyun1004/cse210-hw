public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public void Hide()
    {
        hidden = true;
    }

    public void Reveal()
    {
        hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public string Render()
    {
        return hidden ? new string('_', text.Length) : text;
    }
}
