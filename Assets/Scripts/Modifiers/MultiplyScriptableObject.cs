using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiply", menuName = "Multiply", order = 53)]
public class MultiplyScriptableObject : ModifierScriptableObject
{
    public override int GetModifiedValue(int baseValue, int modifierValue)
    {
        return baseValue * modifierValue;
    }
}
