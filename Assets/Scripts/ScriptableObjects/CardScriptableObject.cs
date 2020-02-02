using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 52)]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private string _rewardType;
    [SerializeField] private int _baseRewardQuantity = 1;
    [SerializeField] private Modifier _modifier;

    public int Number => _number;
    public string RewardType => _rewardType;
    public int BaseRewardQuantity => _baseRewardQuantity;
    public Modifier Modifier => _modifier;
}
