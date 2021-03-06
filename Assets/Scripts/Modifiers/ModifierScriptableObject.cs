﻿using System;
using UnityEngine;

[Serializable]
public abstract class ModifierScriptableObject : ScriptableObject
{
    public abstract int GetModifiedValue(int baseValue, int modifierValue);
}
