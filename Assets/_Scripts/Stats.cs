using UnityEngine;
using System.Collections;

/// <summary>
/// Encapsulates the various stats and attributes of a character
/// </summary>
public class Stats : MonoBehaviour
{

    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }

    public Stats()
    {
        CurrentHealth = MaxHealth = Attack = Defense = 0;
    }
}
