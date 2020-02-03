using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Animator))]
public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _frontSide;
    [SerializeField] private GameObject _backSide;
    [SerializeField] private Text _numberText;
    [SerializeField] private Text _rewardTypeText;
    [SerializeField] private Text _rewardQuantityType;
    [SerializeField] private CardScriptableObject _card;

    private Animator _animator;

    public bool IsFrontSided => _frontSide.activeSelf;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Init(CardDeckView parentDeckView, CardScriptableObject card, int playerLevel = 1)
    {
        _card = card;

        _numberText.text = _card.Number.ToString();
        _rewardTypeText.text = parentDeckView.GetAllowedRewards().GetRewardName(card.RewardType);
        _rewardQuantityType.text = _card.GetRewardQuantity(playerLevel).ToString();
    }

    public void RefreshQuantityText(int playerLevel)
    {
        string quantityText = _card.GetRewardQuantity(playerLevel).ToString();
        _rewardQuantityType.text = quantityText;
    }

    public void ChangeSide()
    {
        _frontSide.gameObject.SetActive(!_frontSide.gameObject.activeSelf);
        _backSide.gameObject.SetActive(!_backSide.gameObject.activeSelf);
    }

    public void FlipToBackSide()
    {
        _animator.SetTrigger("FlipToBack");
    }

    public void FlipToFrontSide()
    {
        _animator.SetTrigger("FlipToFront");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsFrontSided)
        {
            FlipToFrontSide();
        }
    }
}