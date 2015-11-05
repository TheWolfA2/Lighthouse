using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    public LocalParty currentParty;
    public List<Party> inactiveParties = new List<Party>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwapParty()
    {
        if (inactiveParties.Count == 0)
        {
            return;
        }

        inactiveParties.Add(currentParty);
        currentParty.isActive = false;
        currentParty = inactiveParties[0] as LocalParty;
        currentParty.isActive = true;
        inactiveParties.RemoveAt(0);
    }
}
