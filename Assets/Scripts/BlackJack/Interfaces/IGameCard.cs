using UnityEngine;

namespace BlackJack.Interfaces
{
    public interface IGameCard
    {
        public int GetValue();

        public GameObject GetPrefab();
    }
}