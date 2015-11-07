using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


[RequireComponent(typeof(RectTransform))]
public class TextBubble : MonoBehaviour
{
    public int numberOfLines;
    public int speechBubbleHeight;

    public float secondsBetweenWords;
    public float maxSecondsBetweenWords;

    private List<string> _currDialogue;
    private List<string> _cleanDialogue = new List<string>();
    private HtmlStack _tagStack = new HtmlStack();
    private int _currWord;
    private int _currWordIndex;
    private int _currCleanWordIndex;
    private bool showNextButton;
    public bool finishedText;

    void Start()
    {
        _currWord = _currCleanWordIndex = 0;
        _currWordIndex = 0;
        numberOfLines = 3;
        speechBubbleHeight = (int)LayoutUtility.GetPreferredHeight(
            gameObject.GetComponent<RectTransform>()) * numberOfLines;

        string testText = "HELLO WORLD MY <b>NAME</b> IS ALEX I AM A <color=#ff0000>COOL <b>GUY</b></color> WHO DOESN'T AFRAID OF ANYTHING AND GOSH BOY GEE I SURE WONDER WHAT HAPPENS IF THIS GETS TOO LONG<i>Hello</i>";
        SetText(testText);
        SetCleanText();

        maxSecondsBetweenWords = 0.1f;
        secondsBetweenWords = 0;
        showNextButton = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showNextButton && Input.GetKey("up"))
        {
            Text t = this.gameObject.GetComponent<Text>();
            t.text = "";
            showNextButton = false;
        }

        if (_currWord == _currDialogue.Count)
        {
            finishedText = true;
            return;
        }

        if (showNextButton)
        {
            return;
        }

        if (secondsBetweenWords < maxSecondsBetweenWords)
        {
            secondsBetweenWords += Time.deltaTime;
            return;
        }
        secondsBetweenWords = 0f;

        // Checks if it can add the current word in the dialogue array,
        // but only check the letters it hasn't already added
        if (CanAddWord(_cleanDialogue[_currWord].Substring(_currCleanWordIndex)))
        {
            AddNextLetter();
        }
    }

    public void SetText(string newText)
    {
        _currDialogue = new List<string>(newText.Split(' '));
    }

    private void SetCleanText()
    {
        foreach (string s in _currDialogue)
        {
            bool ignore = false;
            string nextWord = "";
            foreach (char c in s)
            {
                if (c == '<')
                {
                    ignore = true;
                    continue;
                }
                else if (c == '>')
                {
                    ignore = false;
                    continue;
                }
                if (!ignore)
                {
                    nextWord += c;
                }
            }
            _cleanDialogue.Add(nextWord);
        }
    }

    private bool CanAddWord(string word)
    {
        Text t = this.gameObject.GetComponent<Text>();
        string prevText = t.text;

        t.text += word;

        // Check if by adding the new word it overflows the container
        RectTransform r = this.gameObject.GetComponent<RectTransform>();

        if (LayoutUtility.GetPreferredHeight(r) > this.speechBubbleHeight)
        {
            //remove that text, wait for the text to be advanced
            t.text = prevText;
            showNextButton = true;
            return false;
        }
        else
        {
            t.text = prevText;
            return true;
        }
    }

    private void AddNextLetter()
    {
        Text t = this.gameObject.GetComponent<Text>();
        char nextLetter = _currDialogue[_currWord][_currWordIndex];
        while (nextLetter == '<')
        {
            string word = _currDialogue[_currWord];
            if (_currDialogue[_currWord][_currWordIndex + 1] != '/')
            {
                _currWordIndex = _tagStack.Push(word, _currWordIndex);
            }
            else
            {
                _currWordIndex = _tagStack.Pop(word, _currWordIndex);
            }

            if (_currWordIndex == -1 || _currWordIndex >= word.Length)
            {
                MoveToNextWord(t);
                if (_currWord >= _currDialogue.Count)
                {
                    return;
                }
            }
            nextLetter = _currDialogue[_currWord][_currWordIndex];
        }
        t.text += _tagStack.GenerateNextChar(nextLetter);
        _currWordIndex++;
        _currCleanWordIndex++;

        if (_currWordIndex == _currDialogue[_currWord].Length)
        {
            MoveToNextWord(t);
        }
    }

    private void MoveToNextWord(Text t)
    {
        t.text += " ";
        _currWordIndex = _currCleanWordIndex = 0;
        _currWord++;
    }
}
