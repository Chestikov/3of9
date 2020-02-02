using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Half Multiply", menuName = "Half Multiply", order = 54)]
public class HalfMultiplyScriptableObject : ModifierScriptableObject
{
    public override int GetModifiedValue(int baseValue, int modifierValue)
    {
        return Convert.ToInt32(Math.Ceiling(baseValue * modifierValue / 2d));
    }
}
