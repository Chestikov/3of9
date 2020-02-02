using UnityEngine;

[CreateAssetMenu(fileName = "New CardDeck", menuName = "Card Deck", order = 51)]
public class CardDeckScriptableObject : ScriptableObject
{
    [SerializeField] private CardScriptableObject[] _cards = new CardScriptableObject[9];

    public CardScriptableObject[] Cards => _cards;
}
