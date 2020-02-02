﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 52)]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private string _rewardType;
    [SerializeField] private int _baseRewardQuantity;
    [SerializeField] private Modifier _modifier;
    [SerializeField] private int _defaultModifierMultiplier = 1;

    public int Number => _number;
    public string RewardType => _rewardType;

    public int GetRewardQuantity(int playerLevel)
    {
        return _modifier == null ? _defaultModifierMultiplier : _modifier.GetModifiedValue(_baseRewardQuantity, playerLevel);
    }
}
