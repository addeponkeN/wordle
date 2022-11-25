using Util;

public class WordGenerator
{
    private string[] _words;
    private ushort[] _indices;
    
    public WordGenerator(string[] words)
    {
        _words = words;
    }
    
    public string GenerateWord()
    {
        return _words[Rng.Next(_words.Length - 1)];
    }
    
}