using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CardView : MonoBehaviour
{
    [SerializeField] private Text _numberText;
    [SerializeField] private Text _rewardTypeText;
    [SerializeField] private Text _rewardQuantityType;
    [SerializeField] private CardScriptableObject _card;

    private RectTransform _rectTransform;

    public void Init(CardDeckView parentDeckView, CardScriptableObject card, int playerLevel = 1)
    {
        _card = card;
        _rectTransform = gameObject.GetComponent<RectTransform>();

        _numberText.text = _card.Number.ToString();
        _rewardTypeText.text = parentDeckView.GetAllowedRewards().GetRewardName(card.RewardType);
        _rewardQuantityType.text = _card.GetRewardQuantity(playerLevel).ToString();
    }

    public void RefreshQuantityText(int playerLevel)
    {
        string quantityText = _card.GetRewardQuantity(playerLevel).ToString();
        _rewardQuantityType.text = quantityText;
    }

    public void SetPosition(Vector2 position)
    {
        _rectTransform.anchoredPosition = position;
    }
}