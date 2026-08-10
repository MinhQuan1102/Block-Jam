using Core;
using UnityEngine;

namespace BlockJam
{
    [RegisterModule("Game Settings")]
    public class GameInitModule : InitModule
    {
        public override string ModuleName => "Game Settings";

        [SerializeField] GameData gameData;

        public override void CreateComponent()
        {
            gameData.Init();
        }
    }
}