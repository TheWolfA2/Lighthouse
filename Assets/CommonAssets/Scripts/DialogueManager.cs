using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
Dialogue should be of this form:
{
    "Dialogue":
    [
        {
            "Speaker": "Leon",
            "Text": "Blah Blah blah blah blah"
        },
        {...}
    ]
}

Rich text formatting will have to come later. But words can be bolded with
html like <b>Bold</b>, <i>Italics</i> and <color=#00ffffff></color>

Since words are being added character by character, we'd need to add some fancy
magic to make it work correctly.

*/

public class DialogueManager : MonoBehaviour
{
    // Attach a dialog box here
     public TextAsset asset;
     public List<SpeechContainer> conversation;
     private int _conversationLocation;

    // Use this for initialization
    void Start () {
        _conversationLocation = 0;
        conversation = readJSON(asset);
    }

    // Update is called once per frame
    void Update () {
         if(conversation.Count == _conversationLocation)
         {
            // Destroy the speech bubble
            // return control back to the player
         }
         // if(!dialogContainer.isFinished){
         //    return;
         // }
         // if(dialogContainer.isFinished){
         //    dialogContainer.setText(nextDialog);
         // }
         _conversationLocation++;
    }

    public List<SpeechContainer> readJSON(TextAsset text)
    {
        List<SpeechContainer> toReturn = new List<SpeechContainer>();

        JSONObject obj = new JSONObject(asset.text);


        if(obj.type != JSONObject.Type.OBJECT)
        {
            Debug.Log("Incorrect JSON format");
            return null;
        }

        JSONObject speechArr = obj.list[0];

        foreach(JSONObject j in speechArr.list){
            if(j.type != JSONObject.Type.OBJECT)
            {
                return null;
            }

            SpeechContainer s = new SpeechContainer(j[0].str, j[1].str);
            toReturn.Add(s);

        }
        return toReturn;
    }

}
