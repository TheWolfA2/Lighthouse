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
    private int _currWord;
    private int _currWordIndex;
    private bool showNextButton;
    public bool finishedText;

    void Start ()
    {
        _currWord = 0;
        _currWordIndex = 0;
        numberOfLines = 3;
        speechBubbleHeight = (int)LayoutUtility.GetPreferredHeight(
            gameObject.GetComponent<RectTransform>()) * numberOfLines;

        string testText = "HELLO WORLD MY <b>NAME</b> IS ALEX I AM A COOL GUY WHO DOESN'T AFRAID OF ANYTHING AND GOSH BOY GEE I SURE WONDER WHAT HAPPENS IF THIS GETS TOO LONG";
        SetText(testText);

        maxSecondsBetweenWords = 0.1f;
        secondsBetweenWords = 0;
        showNextButton = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (showNextButton && Input.GetKey("up"))
        {
            Text t = this.gameObject.GetComponent<Text>();
            t.text = "";
            showNextButton = false;
        }

        if(_currWord == _currDialogue.Count)
        {
            finishedText = true;
            return;
        }

        if(showNextButton)
        {
            return;
        }

        if(secondsBetweenWords < maxSecondsBetweenWords)
        {
            secondsBetweenWords += Time.deltaTime;
            return;
        }
        secondsBetweenWords = 0f;

        // Checks if it can add the current word in the dialogue array,
        // but only check the letters it hasn't already added
        if(CanAddWord(_currDialogue[_currWord].Substring(_currWordIndex)))
        {
            Text t = this.gameObject.GetComponent<Text>();
            t.text += _currDialogue[_currWord][_currWordIndex];
            _currWordIndex++;

            if(_currWordIndex == _currDialogue[_currWord].Length)
            {
                t.text += " ";
                _currWordIndex = 0;
                _currWord++;
            }
        }
    }

    public void SetText(string newText)
    {
        _currDialogue = new List<string>(newText.Split(' '));
    }

    private bool CanAddWord(string word)
    {
        Text t = this.gameObject.GetComponent<Text>();
        string prevText = t.text;

        t.text += word;

        // Check if by adding the new word it overflows the container
        RectTransform r = this.gameObject.GetComponent<RectTransform>();

        if(LayoutUtility.GetPreferredHeight(r) > this.speechBubbleHeight)
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
}
