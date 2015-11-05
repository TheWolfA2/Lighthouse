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

    private List<string> _currText;
    private int _currWord;
    private bool showNextButton;
    public bool finishedText;

    void Start ()
    {
        _currWord = 0;
        numberOfLines = 3;
        speechBubbleHeight = (int)LayoutUtility.GetPreferredHeight(
            gameObject.GetComponent<RectTransform>()) * numberOfLines;

        string testText = "HELLO WORLD MY NAME IS ALEX I AM A COOL GUY WHO DOESN'T AFRAID OF ANYTHING AND GOSH BOY GEE I SURE WONDER WHAT HAPPENS IF THIS GETS TOO LONG";
        setText(testText);

        maxSecondsBetweenWords = 0.2f;
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


        if(_currWord == _currText.Count)
        {
            finishedText = true;
            return;
        }

        if(showNextButton)
        {
            return;
        }
        if(secondsBetweenWords < maxSecondsBetweenWords){
            secondsBetweenWords += Time.deltaTime; ;

            return;
        }

        secondsBetweenWords = 0f;
        addWord(_currWord);

    }

    public void setText(string newText)
    {
        _currText = new List<string>(newText.Split(' '));
    }

    private void addWord(int index)
    {
        Text t = this.gameObject.GetComponent<Text>();
        string prevText = t.text;
        t.text += " " + _currText[index];

        // Check if by adding the new word it overflows the container
        RectTransform r = this.gameObject.GetComponent<RectTransform>();

        if(LayoutUtility.GetPreferredHeight(r) > this.speechBubbleHeight)
        {
            //remove that text, wait for the text to be advanced
            t.text = prevText;
            showNextButton = true;
            return;
        }
        _currWord++;
    }
}
