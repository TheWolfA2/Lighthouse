using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions as a base class container for Characters
/// </summary>
public class Party : MonoBehaviour, ICollection<Character>
{
    public bool isActive = false;
    public Character leader;
    private List<Character> _partyMembers = new List<Character>();

    public Character this[int index]
    {
        get
        {
            if (index < 0 || index > _partyMembers.Count)
            {
                throw new IndexOutOfRangeException("Index was not valid for number of party members");
            }
            return _partyMembers[index];
        }
    }

    #region ICollection interface
    public int Count
    {
        get
        {
            return ((ICollection<Character>)_partyMembers).Count;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((ICollection<Character>)_partyMembers).IsReadOnly;
        }
    }

    public void Add(Character item)
    {
        ((ICollection<Character>)_partyMembers).Add(item);
    }

    public void Clear()
    {
        ((ICollection<Character>)_partyMembers).Clear();
    }

    public bool Contains(Character item)
    {
        return ((ICollection<Character>)_partyMembers).Contains(item);
    }

    public void CopyTo(Character[] array, int arrayIndex)
    {
        ((ICollection<Character>)_partyMembers).CopyTo(array, arrayIndex);
    }

    public bool Remove(Character item)
    {
        return ((ICollection<Character>)_partyMembers).Remove(item);
    }

    public IEnumerator<Character> GetEnumerator()
    {
        return ((ICollection<Character>)_partyMembers).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((ICollection<Character>)_partyMembers).GetEnumerator();
    }
    #endregion
}
