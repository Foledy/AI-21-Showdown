using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Interfaces;
using Random = UnityEngine.Random;

namespace BlackJack
{
    public class CardDealer : ICardDealer
    {
        private IGameCardSet _cardSet;
        private Queue<GameCard> _firstDeck;
        private Queue<GameCard> _secondDeck;
        private Queue<GameCard> _thirdDeck;

        public CardDealer(IGameCardSet cardSet)
        {
            _cardSet = cardSet;
            
            _firstDeck = new Queue<GameCard>();
            _secondDeck = new Queue<GameCard>();
            _thirdDeck = new Queue<GameCard>();
            
            SplitSetToDecks();
        }

        public GameCard GetCard(DeckNumberType type)
        {
            switch (type)
            {
                case DeckNumberType.First:
                    if (_firstDeck.Count == 0)
                    {
                        throw new NullReferenceException("[CardDealer] Card deck №1 has no card left");
                    }
                    
                    return _firstDeck.Dequeue();
                case DeckNumberType.Second:
                    if (_secondDeck.Count == 0)
                    {
                        throw new NullReferenceException("[CardDealer] Card deck №2 has no card left");
                    }
                    
                    return _secondDeck.Dequeue();
                case DeckNumberType.Third:
                    if (_thirdDeck.Count == 0)
                    {
                        throw new NullReferenceException("[CardDealer] Card deck №3 has no card left");
                    }
                    
                    return _thirdDeck.Dequeue();
                
                default:
                    throw new ArgumentException("[CardDealer] Number of deck must be (1, 2, 3)");
            }
        }

        public void MixCardDecks()
        {
            SplitSetToDecks();
        }

        public void ChangeCardDeck(IGameCardSet set)
        {
            _cardSet = set ?? throw new ArgumentException("[CardDealer] CardSet can not be null!");
        }

        private void SplitSetToDecks()
        {
            var cardSet = GetMixedCardSet(_cardSet.Get());
            var length = cardSet.Count;

            _firstDeck.Clear();
            _secondDeck.Clear();
            _thirdDeck.Clear();

            for (var i = 0; i < length / 3; i++)
            {
                _firstDeck.Enqueue(cardSet.Dequeue());
                _secondDeck.Enqueue(cardSet.Dequeue());
                _thirdDeck.Enqueue(cardSet.Dequeue());
            }

            if (cardSet.Count != 0)
            {
                _firstDeck.Enqueue(cardSet.Dequeue());
            }
        }

        private Queue<GameCard> GetMixedCardSet(List<GameCard> source)
        {
            var cardSet = new Queue<GameCard>();
            var length = source.Count;

            for (var i = 0; i < 100; i++)
            {
                var first = Random.Range(0, length - 1);
                var second = Random.Range(0, length - 1);

                (source[first], source[second]) = (source[second], source[first]);
            }

            foreach (var card in source)
            {
                cardSet.Enqueue(card);
            }

            return cardSet;
        }
    }
}