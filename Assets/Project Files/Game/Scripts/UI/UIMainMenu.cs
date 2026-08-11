using Core;
using UnityEngine;

namespace BlockJam
{
    public class UIMainMenu : UIPage
    {
        public readonly float BUTTONS_RIGHT_OFFSET_X = 300F;
        [BoxGroup("References", "References")]
        [SerializeField] RectTransform safeAreaRectTransform;
        [BoxGroup("Side Buttons", "Side Buttons")]
        [SerializeField] UIMainMenuButton noAdsButton;
        [BoxGroup("Side Buttons")]
        [SerializeField] UIMainMenuButton storeButton;
        [BoxGroup("Side Buttons")]
        [SerializeField] UIMainMenuButton skinsStoreButton;

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        public override void PlayHideAnimation()
        {
            throw new System.NotImplementedException();
        }

        public override void PlayShowAnimation()
        {
            throw new System.NotImplementedException();
        }
    }

}
