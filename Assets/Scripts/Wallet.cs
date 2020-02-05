using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private List<ResourceAmount> _resources;

    public void IncreaseResourceAmount(ResourceAmount resourceAmount)
    {
        if (TryFindResource(resourceAmount.ResourceType, out ResourceAmount resource))
        {
            resource.ChangeValue(resourceAmount.Value);
        }
        else
        {
            _resources.Add(resourceAmount);
        }
    }

    public bool TryDecreaseResourceAmount(ResourceAmount resourceAmount)
    {
        if (TryFindResource(resourceAmount.ResourceType, out ResourceAmount resource))
        {
            if (resource.Value >= resourceAmount.Value)
            {
                resource.ChangeValue(-resourceAmount.Value);
                return true;
            }
        }

        return false;
    }

    private bool TryFindResource(ResourceType type, out ResourceAmount resourceToFind)
    {
        foreach (var resource in _resources)
        {
            if (resource.ResourceType == type)
            {
                resourceToFind = resource;
                return true;
            }
        }

        resourceToFind = new ResourceAmount();
        return false;
    }
}
