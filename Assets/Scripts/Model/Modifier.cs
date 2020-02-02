using System;
using UnityEngine;

[Serializable]
public abstract class Modifier : ScriptableObject
{
    public abstract int GetModifiedValue(int baseValue, int modifierValue);
}
