using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;
    [SerializeField] private CardDeckScriptableObject _cardDeckValues;
    [SerializeField] private Level _level;

    private List<Card> _cards;

    private void Start()
    {
        FillDeck();
    }

    private void FillDeck()
    {
        if (_cardDeckValues != null)
        {
            _cards = new List<Card>();

            for (int i = 0; i < _cardDeckValues.Cards.Length; i++)
            {
                var card = Instantiate(_cardPrefab.gameObject, gameObject.transform).GetComponent<Card>();
                card.Init(_cardDeckValues.Cards[i], _level.GetLevel());
                _level.LevelChanged += card.RefreshQuantityText;

                card.SetPosition(CalculateCardPosition(i));
                _cards.Add(card);
            }
        }
    }

    private Vector2 CalculateCardPosition(int index)
    {
        float posX = index % 3 * (_cardPrefab.GetComponent<RectTransform>().rect.width + 100);
        float posY = index / 3 * (_cardPrefab.GetComponent<RectTransform>().rect.height + 50);
        return new Vector2(-400, 250) + new Vector2(posX, -posY);
    }
}
