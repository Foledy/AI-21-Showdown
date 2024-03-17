using UnityEngine;

namespace BlackJack.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlackJack Settings", menuName = "BlackJack/Create new BlackJack Settings", order = 0)]
    public class BlackJackSettings : ScriptableObject
    {
        public int PointsToWin;
        [Tooltip("Place '-1' for unlimited time")]
        public float TimePerMove;
    }
}