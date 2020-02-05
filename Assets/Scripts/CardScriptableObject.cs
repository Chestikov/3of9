using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 52)]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] ResourceAmount _reward;
    [SerializeField] private ModifierScriptableObject _modifier;
    [SerializeField] private int _defaultModifierMultiplier = 1;

    public int Number => _number;
    public ResourceType RewardType => _reward.ResourceType;

    public int GetRewardQuantity(int playerLevel)
    {
        return _modifier == null ? _defaultModifierMultiplier : _modifier.GetModifiedValue(_reward.Value, playerLevel);
    }
    
    public ResourceAmount GetResourceAmount(int playerLevel)
    {
        ResourceAmount resourceAmount = new ResourceAmount();
        resourceAmount.Init(RewardType, GetRewardQuantity(playerLevel));
        return resourceAmount;
    }
}
