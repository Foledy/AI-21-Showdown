using BlackJack.ScriptableObjects;
using BlackJack.Types;

namespace BlackJack.Interfaces
{
    public interface ICardDealer
    {
        public GameCard GetCard(DeckNumberType type);
        public void MixCardDecks();
        public void ChangeCardDeck(IGameCardSet set);
    }
}