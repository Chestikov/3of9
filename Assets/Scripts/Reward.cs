using System;
using UnityEngine;

[Serializable]
public class Reward
{
    [SerializeField] private RewardType _type;
    [SerializeField] private string _name;

    public RewardType Type => _type;
    public string Name => _name;
}
