using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class Card : MonoBehaviour
{
    [SerializeField] private Text _numberText;
    [SerializeField] private Text _rewardTypeText;
    [SerializeField] private Text _rewardQuantityType;

    private int _number;
    private string _rewardType;
    private int _baseRewardQuantity = 1;
    private Modifier _modifier;
    private readonly int _defaultModifierMultiplier = 1;
    private RectTransform _rectTransform;

    public void Init(CardScriptableObject cardValues, int playerLevel = 1)
    {
        _number = cardValues.Number;
        _rewardType = cardValues.RewardType;
        _baseRewardQuantity = cardValues.BaseRewardQuantity;
        _modifier = cardValues.Modifier;
        _rectTransform = gameObject.GetComponent<RectTransform>();

        _numberText.text = _number.ToString();
        _rewardTypeText.text = _rewardType;
        _rewardQuantityType.text = GetRewardQuantity(playerLevel).ToString();
    }

    public int GetRewardQuantity(int playerLevel)
    {
        return _modifier == null ? _defaultModifierMultiplier : _modifier.GetModifiedValue(_baseRewardQuantity, playerLevel);
    }

    public void RefreshQuantityText(int playerLevel)
    {
        string quantityText = GetRewardQuantity(playerLevel).ToString();
        _rewardQuantityType.text = quantityText;
    }

    public void SetPosition(Vector2 position)
    {
        _rectTransform.anchoredPosition = position;
    }
}