using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rewards", menuName = "Rewards", order = 55)]
public class RewardsScriptableObject : ScriptableObject
{
    [SerializeField] private List<Reward> _rewards;

    public string GetRewardName(RewardType rewardType)
    {
        return _rewards.Where(x => x.Type == rewardType)
                       .Select(x => x.Name)
                       .FirstOrDefault();
    }
}
