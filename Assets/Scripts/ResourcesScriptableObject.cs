using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rewards", menuName = "Rewards", order = 55)]
public class ResourcesScriptableObject : ScriptableObject
{
    [SerializeField] private List<Resource> _rewards;

    public string GetRewardName(ResourceType rewardType)
    {
        return _rewards.Where(x => x.Type == rewardType)
                       .Select(x => x.Name)
                       .FirstOrDefault();
    }
}
