using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public string Name { get; private set;}
    public Stats Attributes { get; private set; }

    public Character()
    {
        Name = "";
        Attributes = null;
    }

    public Character(string inName)
    {
        Name = inName;
        Attributes = new Stats();
    }
}
