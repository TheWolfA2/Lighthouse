using System.Collections.Generic;

public class HtmlStack
{
    Stack<string> _tagStack = new Stack<string>();

    /// <summary>
    /// Pushes the tag at start+1 onto the stack and returns the index of the character
    /// following the closing character of the tag
    /// </summary>
    /// <param name="word">The current word being evaluated</param>
    /// <param name="start">The index at which to start looking for the closing tag character</param>
    /// <returns>The index following the closing tag character</returns>
    public int Push(string word, int start=0)
    {
        int end = word.IndexOf('>', start);
        _tagStack.Push(word.Substring(start + 1, end - (start + 1)));
        start = end + 1; // Move start to character after close of open tag
        return start;
    }

    /// <summary>
    /// Removes the most recently added tag from the stack, and returns the
    /// index following the closing character of a tag in word.
    /// </summary>
    /// <param name="word">The current word being checked</param>
    /// <param name="start">The starting index to searching for the closing tag character</param>
    /// <returns>The index of the closing tag character, or -1</returns>
    public int Pop(string word, int start=0)
    {
        if (_tagStack.Count == 0)
        {
            return -1;
        }
        _tagStack.Pop();
        return word.IndexOf('>', start) + 1;
    }

    /// <summary>
    /// Generates the string containing the provided letter wrapped in the
    /// tags currently present.
    /// </summary>
    /// <param name="letter">The letter to wrap in tags</param>
    /// <returns>The string with the letter wrapped in tags</returns>
    public string GenerateNextChar(char letter)
    {
        string retVal = "";
        foreach (string s in _tagStack)
        {
            
            retVal += "<" + s + ">";
        }
        retVal += letter;

        // Iterate in reverse to build closing tags in reverse order
        for (int i = _tagStack.Count - 1; i >= 0; i--)
        {
            string s = _tagStack.ToArray()[i];
            // Need to replace any =val in a tag e.g. <color=#ff0000>
            int end = s.IndexOf('=');
            if (end == -1)
            {
                end = s.Length;
            }
            retVal += "</" + s.Substring(0, end) + ">";
        }
        return retVal;
    }
}
