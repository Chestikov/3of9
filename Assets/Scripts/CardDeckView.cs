using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckView : MonoBehaviour
{
    [SerializeField] private CardView _cardViewPrefab;
    [SerializeField] private CardDeckScriptableObject _cardDeckValues;
    [SerializeField] private Level _level;
    [SerializeField] private RewardsScriptableObject _allowedRewards;

    private List<CardView> _cards;

    private void Start()
    {
        FillDeck();
    }

    public RewardsScriptableObject GetAllowedRewards()
    {
        return _allowedRewards;
    }

    private void FillDeck()
    {
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

    private Vector2 CalculateCardPosition(int index)
    {
        float posX = index % 3 * (_cardViewPrefab.GetComponent<RectTransform>().rect.width + 100);
        float posY = index / 3 * (_cardViewPrefab.GetComponent<RectTransform>().rect.height + 50);
        return new Vector2(-400, 250) + new Vector2(posX, -posY);
    }
}
