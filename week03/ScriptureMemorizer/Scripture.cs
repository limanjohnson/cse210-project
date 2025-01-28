namespace ScriptureMemorizer;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private string _originalVerse;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _originalVerse = text;
    }

    // Public property to access the reference
    public Reference Reference
    {
        get { return _reference; }
    }

    public void HideRandomWords(int numberToHide)
    {
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        if (visibleWords.Count == 0) return;

        var randomWord = new Random();

        // Select random words to hide
        for (int i = 0; i < numberToHide; i++)
        {
            // Words not currently hidden
            var shownWords = _words.Where(word => !word.IsHidden()).ToList();

            // Check there are still shown words that need to be hidden
            if (shownWords.Count == 0) break;

            // Choose random words from the list to hide
            var wordToHide = shownWords[randomWord.Next(shownWords.Count)];
            wordToHide.Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n\n" + string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void Reset()
    {
        _words = _originalVerse.Split(' ').Select(word => new Word(word)).ToList();
    }
}