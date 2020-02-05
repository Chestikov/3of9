using System;
using UnityEngine;

[Serializable]
public class ResourceAmount
{
    [SerializeField] private int _value = 0;
    [SerializeField] private ResourceType _resourceType;

    public int Value => _value;
    public ResourceType ResourceType => _resourceType;

    public void Init(ResourceType resourceType, int value = 0)
    {
        _value = value;
        _resourceType = resourceType;
    }

    public void ChangeValue(int amount)
    {
        _value += amount;
    }
}
