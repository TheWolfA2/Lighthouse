using UnityEngine;
using System.Collections;

/// <summary>
/// Encapsulates the various stats and attributes of a character
/// </summary>
public class Stats : MonoBehaviour
{

    public int CurrentHealth;
    public int MaxHealth;
    public int Attack;
    public int Defense;

    public Stats()
    {
        CurrentHealth = MaxHealth = Attack = Defense = 0;
    }

    public override string ToString()
    {
        return string.Format("Current Health: {0}, Max Health: {1}, Attack: {2}, Defense: {3}",
            CurrentHealth, MaxHealth, Attack, Defense);
    }
}
