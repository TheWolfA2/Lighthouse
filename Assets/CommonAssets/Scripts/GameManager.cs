using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public PartyManager partyManager;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwapParties()
    {
        if (partyManager != null)
        {
            partyManager.SwapParty();
        }
    }
}
