using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = new List<Word>();

        string[] splitWords = text.Split(' ');
        foreach (string w in splitWords)
        {
            words.Add(new Word(w));
        }
    }

    // Hides only words that are still visible
    public void HideRandomWords(int count)
    {
        Random rng = new Random();
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = rng.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string Render()
    {
        List<string> rendered = new List<string>();

        foreach (Word word in words)
        {
            rendered.Add(word.Render());
        }

        return $"{reference.ToDisplayString()} {string.Join(" ", rendered)}";
    }

    public bool IsFullyHidden()
    {
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
