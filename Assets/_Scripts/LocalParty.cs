using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocalParty : Party
{

    public LocalParty() : base()
    {

    }

    public LocalParty(Character inLeader, List<Character> characters) : base(inLeader, characters)
    {

    }
}
