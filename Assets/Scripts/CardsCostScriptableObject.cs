using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cards Cost", menuName = "Cards Cost", order = 56)]
public class CardsCostScriptableObject : ScriptableObject
{
    [SerializeField] List<ResourceAmount> _cardsCost;

    public ResourceAmount GetCardCost(int cardNumber)
    {
        int cardIndex = cardNumber - 1;

        bool cardIndexInBounds = (cardIndex < _cardsCost.Count) && (cardIndex >= 0);

        if (cardIndexInBounds)
        {
            return _cardsCost[cardIndex];
        }
        
        return new ResourceAmount();
    }
}
