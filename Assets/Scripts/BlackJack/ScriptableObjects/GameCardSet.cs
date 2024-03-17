using System.Collections.Generic;
using BlackJack.Interfaces;
using UnityEngine;

namespace BlackJack
{
    [CreateAssetMenu(fileName = "GameCardSet", menuName = "BlackJack/Create new CardSet")]
    public class GameCardSet : ScriptableObject, IGameCardSet
    {
        [SerializeField] private List<GameCard> _cards;

        public List<GameCard> Get() => _cards;
    }
}