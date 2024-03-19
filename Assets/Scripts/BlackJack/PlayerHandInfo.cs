using System.Collections.Generic;
using BlackJack.ScriptableObjects;

namespace BlackJack
{
    public class PlayerHandInfo
    {
        private List<GameCard> _cards;
        private int _totalPoints;
        private int _winningPoints;

        public PlayerHandInfo(int winningPoints)
        {
            _winningPoints = winningPoints;
            _cards = new();
        }
        
        public void AddCard(GameCard card)
        {
            _cards.Add(card);

            var points = card.GetValue();

            if (points == 11 && points + _totalPoints > 21)
            {
                points = 1;
            }
            
            _totalPoints += card.GetValue();
        }
        
        public int GetPoints() => _totalPoints;
    }
}