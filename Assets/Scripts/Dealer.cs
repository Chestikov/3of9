using System;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _cardsToOpen = 5;
    [SerializeField] private CardsCostScriptableObject _cardsCost;

    public event Action RoundEnded;

    public bool CanOpenNextCard(int numberOfCardsOpen)
    {
        int numberOfCardToOpen = numberOfCardsOpen + 1;
        bool canOpen = false;

        if (numberOfCardToOpen <= _cardsToOpen)
        {
            canOpen = TryPayForOpen(numberOfCardToOpen);
        }

        if (numberOfCardToOpen == _cardsToOpen)
        {
            RoundEnded?.Invoke();
        }

        return canOpen;
    }

    public void GiveReward(ResourceAmount reward)
    {
        _wallet.IncreaseResourceAmount(reward);
    }

    private bool TryPayForOpen(int numberOfCard)
    {
        ResourceAmount cost = _cardsCost.GetCardCost(numberOfCard);
        return _wallet.TryDecreaseResourceAmount(cost);
    }
}
