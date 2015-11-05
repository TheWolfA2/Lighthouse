using UnityEngine;
using System.Collections;

/// <summary>
/// Encapsulates the various stats and attributes of a character
/// </summary>
public class Stats : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public int attack;
    public int defense;

    public Stats()
    {
        currentHealth = maxHealth = attack = defense = 0;
    }

    public override string ToString()
    {
        return string.Format("Current Health: {0}, Max Health: {1}, Attack: {2}, Defense: {3}",
            currentHealth, maxHealth, attack, defense);
    }
}
