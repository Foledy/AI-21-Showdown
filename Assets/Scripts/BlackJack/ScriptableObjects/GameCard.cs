using BlackJack.Interfaces;
using UnityEngine;

namespace BlackJack.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameCard", menuName = "BlackJack/Create Game Card", order = 0)]
    public class GameCard : ScriptableObject, IGameCard
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _value;

        public int GetValue() => _value;

        public GameObject GetPrefab() => _prefab;
    }
}