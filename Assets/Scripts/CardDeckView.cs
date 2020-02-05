using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private Dealer _dealer;

    private List<CardView> _cards;
    private Animator _animator;
    private bool _readyToPlay = false;

    public int CardsOpened => _cards.Where(x => x.IsFrontSided == true).Count();

    private void Start()
    {
        Init();

        StartCoroutine(StartRound());
    }

    private void OnEnable()
    {
        _dealer.RoundEnded += StartNewRound;
    }

    private void OnDisable()
    {
        foreach (var card in _cards)
        {
            card.CardClicked -= OnCardClicked;
        }

        _dealer.RoundEnded -= StartNewRound;
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

                card.CardClicked += OnCardClicked;
                _cards.Add(card);
            }
        }
    }

    public ResourcesScriptableObject GetRewardsCatalog()
    {
        return _rewardsCatalog;
    }

    public IEnumerator StartRound()
    {
        SortCards();

        DealCards();
        yield return new WaitForSeconds(2);

        ShowCardsFrontSide();
        yield return new WaitForSeconds(3);

        ShowCardsBackSide();
        yield return new WaitForSeconds(1);

        CollectCardsInDeck();
        yield return new WaitForSeconds(2);

        ShuffleCards();

        DealCards();

        _readyToPlay = true;
    }

    public IEnumerator RestartRound()
    {
        yield return new WaitForSeconds(2);

        ShowCardsBackSide();
        yield return new WaitForSeconds(1);

        CollectCardsInDeck();
        yield return new WaitForSeconds(2);

        SortCards();

        StartCoroutine(StartRound());
    }

    public void StartNewRound()
    {
        _readyToPlay = false;

        StartCoroutine(RestartRound());
    }

    private void ShowCardsFrontSide()
    {
        foreach (var card in _cards)
        {
            card.FlipToFrontSide();
        }
    }

    private void ShowCardsBackSide()
    {
        foreach (var card in _cards)
        {
            card.FlipToBackSide();
        }
    }

    private void CollectCardsInDeck()
    {
        _animator.SetTrigger("CollectCards");
    }

    private void SortCards()
    {
        for (int i = 0; i < _cards.Count; i++)
        {
            int cardNumber = _cards[i].Number - 1;
            _cards[i].transform.SetSiblingIndex(cardNumber);
        }
    }

    private void ShuffleCards()
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

    private void DealCards()
    {
        _animator.SetTrigger("DealCards");
    }

    private void OnCardClicked(CardView cardView)
    {
        if (_readyToPlay && _dealer.CanOpenNextCard(CardsOpened))
        {
            cardView.FlipToFrontSide();

            int playerLevel = _level.GetLevel();
            ResourceAmount reward = cardView.Card.GetResourceAmount(playerLevel);

            _dealer.GiveReward(reward);
        }
    }
}
