using System.Collections.Generic;
using BlackJack.ScriptableObjects;

namespace BlackJack.Interfaces
{
    public interface IGameCardSet
    {
        public List<GameCard> Get();
    }
}