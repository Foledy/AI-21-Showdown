using System;
using BlackJack.Interfaces;
using BlackJack.ScriptableObjects;
using BlackJack.Types;
using UnityEngine;

namespace BlackJack
{
    public class BlackJackGame : MonoBehaviour
    {
        [SerializeField] private GameCardSet _cardSet;
        [SerializeField] private BlackJackSettings _gameSettings;

        public event Action OnMovePassed;
        public event Action<GameResult> OnGameFinished;
        public event Action<GameCard> OnMoved;
        
        private ICardDealer _dealer;
        private PlayerHandInfo _playerHandInfo;
        private PlayerHandInfo _enemyHandInfo;
        private bool _isGameActive;

        private void Awake()
        {
            _dealer = new CardDealer(_cardSet);
        }

        public void StartGame()
        {
            ResetGame();
            
            _isGameActive = true;
        }

        public void DoMove(BlackJackMoveType moveType, PlayerType playerType = PlayerType.None, DeckNumberType deckNumber = DeckNumberType.None)
        {
            if (playerType == PlayerType.None)
            {
                throw new ArgumentException("[BlackJackGame] PlayerType can not be 'None'!");
            }

            var result = GameResult.None;
            
            switch (moveType)
            {
                case BlackJackMoveType.GetCard:
                    if (deckNumber == DeckNumberType.None)
                    {
                        throw new ArgumentException("[BlackJackGame] Deck number can not be 'None'!");
                    }
                    
                    var card = GetCard(deckNumber);
                    var points = 0;
                    
                    if (playerType == PlayerType.Player)
                    {
                        _playerHandInfo.AddCard(card);

                        points = _playerHandInfo.GetPoints();
                    }
                    else
                    {
                        _enemyHandInfo.AddCard(card);

                        points = _enemyHandInfo.GetPoints();
                    }
                    
                    if (HavePointsExceededLimit(points))
                    {
                        result = playerType == PlayerType.Player ? GameResult.Lose : GameResult.Win;
                    }
                    else if (HaveWinningPoints(points))
                    {
                        result = playerType == PlayerType.Player ? GameResult.Win : GameResult.Lose;
                    }

                    break;
                case BlackJackMoveType.Stop:
                    var enemyPoints = _enemyHandInfo.GetPoints();
                    var playerPoints = _playerHandInfo.GetPoints();
                    
                    if (enemyPoints != 0 && playerPoints != 0)
                    {
                        if (playerPoints == enemyPoints)
                        {
                            result = GameResult.Draw;
                        }
                        else
                        {
                            result = enemyPoints > playerPoints ? GameResult.Lose : GameResult.Win;
                        }
                    }
                    else
                    {
                        OnMovePassed?.Invoke();
                    }

                    break;
                
                default:
                    throw new ArgumentException("[BlackJackGame] MoveType can not be 'None'!");
            }

            if (result != GameResult.None)
            {
                OnGameFinished?.Invoke(result);
            }
        }

        public PlayerHandInfo GetMyHand(PlayerType type) =>
            type == PlayerType.Player ? _playerHandInfo : _enemyHandInfo;

        private GameCard GetCard(DeckNumberType number)
        {
            if (_isGameActive)
            {
                var card = _dealer.GetCard(number);
            
                OnMoved?.Invoke(card);

                return card;
            }

            return null;
        }
        
        private void ResetGame()
        {
            _isGameActive = false;
            
            _playerHandInfo = new PlayerHandInfo(_gameSettings.PointsToWin);
            _enemyHandInfo = new PlayerHandInfo(_gameSettings.PointsToWin);
            
            _dealer.MixCardDecks();
        }

        private bool HavePointsExceededLimit(int points) => points > _gameSettings.PointsToWin;

        private bool HaveWinningPoints(int points) => points == _gameSettings.PointsToWin;
    }
}