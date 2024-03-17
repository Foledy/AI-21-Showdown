using BlackJack.Interfaces;
using UnityEngine;

namespace BlackJack
{
    [CreateAssetMenu(fileName = "GameCard", menuName = "BlackJack/Create Game Card", order = 0)]
    public class GameCard : ScriptableObject, IGameCard
    {
        [SerializeField] private Sprite _image;
        [SerializeField] private int _value;

        public int GetValue() => _value;

        public Sprite GetSprite() => _image;
    }
}