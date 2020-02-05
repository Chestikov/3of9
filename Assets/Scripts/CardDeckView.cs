using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(Animator))]
public class CardDeckView : MonoBehaviour
{
    [SerializeField] private CardView _cardViewPrefab;
    [SerializeField] private CardDeckScriptableObject _cardDeckValues;
    [SerializeField] private Level _level;
    [SerializeField] private ResourcesScriptableObject _rewardsCatalog;

    private List<CardView> _cards;
    private Animator _animator;

    private void Start()
    {
        Init();

        DealCards();
    }

    public void Init()
    {
        _animator = GetComponent<Animator>();

        if (_cardDeckValues != null)
        {
            _cards = new List<CardView>();

            for (int i = 0; i < _cardDeckValues.Cards.Length; i++)
            {
                var card = Instantiate(_cardViewPrefab.gameObject, gameObject.transform).GetComponent<CardView>();
                card.Init(this, _cardDeckValues.Cards[i], _level.GetLevel());
                _level.LevelChanged += card.RefreshQuantityText;

                _cards.Add(card);
            }
        }
    }

    public ResourcesScriptableObject GetRewardsCatalog()
    {
        return _rewardsCatalog;
    }

    public void ShowCardsFrontSide()
    {
        foreach (var card in _cards)
        {
            card.FlipToFrontSide();
        }
    }

    public void ShowCardsBackSide()
    {
        foreach (var card in _cards)
        {
            card.FlipToBackSide();
        }
    }

    public void CollectCardsInDeck()
    {
        _animator.SetTrigger("CollectCards");
    }

    public void ShuffleCards()
    {
        Random random = new Random();
        
        int cardsQuantity = _cards.Count;

        while (cardsQuantity > 1)
        {
            cardsQuantity--;
            int index = random.Next(cardsQuantity + 1);
            CardView tempValue = _cards[index];
            _cards[index] = _cards[cardsQuantity];
            _cards[cardsQuantity] = tempValue;

            _cards[cardsQuantity].transform.SetSiblingIndex(cardsQuantity);
        }
    }

    public void DealCards()
    {
        _animator.SetTrigger("DealCards");
    }
}
