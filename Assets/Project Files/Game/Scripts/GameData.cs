using UnityEngine;

namespace BlockJam
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "Data/Game Data")]
    public class GameData : ScriptableObject
    {
        public static GameData Data { get; private set; }

        public void Init()
        {
            Data = this;
        }
    }
}