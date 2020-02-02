using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Multiply", menuName = "Multiply", order = 53)]
public class MultiplyScriptableObject : Modifier
{
    public override int GetModifiedValue(int baseValue, int modifierValue)
    {
        return baseValue * modifierValue;
    }
}
