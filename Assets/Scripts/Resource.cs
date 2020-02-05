using System;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField] private ResourceType _type;
    [SerializeField] private string _name;

    public ResourceType Type => _type;
    public string Name => _name;
}
