using System.Collections.Generic;
using BlackJack.ScriptableObjects;

namespace BlackJack
{
    public class PlayerHandInfo
    {
        private List<GameCard> _cards = new();
        private int _totalPoints;

        public void AddCard(GameCard card)
        {
            _cards.Add(card);

            _totalPoints += card.GetValue();
        }
        
        public int GetPoints() => _totalPoints;
    }
}