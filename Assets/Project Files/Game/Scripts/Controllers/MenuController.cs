using Core;
using UnityEngine;

namespace BlockJam
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] UIController uiController;

        private void Awake()
        {
            GameData gameData = GameData.Data;
            if (gameData == null)
                Debug.LogError("GameData is null. Please add the Game Settings component to the Project Init Settings and link Game Data scriptable object.");

            uiController.Init();
        } 

        private void Start()
        {
            // Display default page
            UIController.ShowPage<UIMainMenu>();

            Overlay.Hide(0.3f);
        }
    }
}