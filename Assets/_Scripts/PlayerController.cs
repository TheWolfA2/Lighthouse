using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public PlayerCharacter PlayerData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    void FixedUpdate()
    {
        Debug.Log("Name: " + PlayerData.CharacterName);
        Debug.Log("Attributes: " + PlayerData.Attributes.ToString());
    }
}
