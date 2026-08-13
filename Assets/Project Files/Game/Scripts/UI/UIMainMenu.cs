using Core;
using UnityEngine;
using UnityEngine.UI;

namespace BlockJam
{
    public class UIMainMenu : UIPage
    {
        public readonly float BUTTONS_RIGHT_OFFSET_X = 300F;
        [BoxGroup("References", "References")]
        [SerializeField] RectTransform safeAreaRectTransform;
        [BoxGroup("Top Panel", "Top Panel")]
        [SerializeField] CurrencyUIPanelSimple coinsPanel;
        [BoxGroup("Buttons", "Buttons")]
        [SerializeField] Button settingsButton;
        [BoxGroup("Side Buttons", "Side Buttons")]
        [SerializeField] UIMainMenuButton noAdsButton;
        [BoxGroup("Side Buttons")]
        [SerializeField] UIMainMenuButton storeButton;
        [BoxGroup("Side Buttons")]
        [SerializeField] UIMainMenuButton skinsStoreButton;
        private UIScaleAnimation coinsLabelScalable;

        public override void Init()
        {
            Debug.Log("INIT MAIN MENU");
            coinsLabelScalable = new UIScaleAnimation(coinsPanel);
            // coinsPanel.Init();
            Debug.Log("INIT MAIN MENU1");

            noAdsButton.Init(BUTTONS_RIGHT_OFFSET_X);
            storeButton.Init(BUTTONS_RIGHT_OFFSET_X);
            skinsStoreButton.Init(BUTTONS_RIGHT_OFFSET_X);

            Debug.Log("INIT MAIN MENU2");
            settingsButton.onClick.AddListener(SettingsButton);
            noAdsButton.Button.onClick.AddListener(NoAdButton);
            // storeButton.Button.onClick.AddListener(StoreButton);
            // skinsStoreButton.Button.onClick.AddListener(OnSkinsStoreButtonClicked);
            // coinsPanel.AddButton.onClick.AddListener(AddCoinsButton);
        }

        public override void PlayHideAnimation()
        {
            UIController.OnPageClosed(this);
        }

        public override void PlayShowAnimation()
        {
            UIController.OnPageOpened(this);
        }

        #region Side Buttons

        // private void ShowAdButton(bool immediately = false)
        // {
        //     if (AdsManager.IsForcedAdEnabled())
        //     {
        //         noAdsButton.Show(immediately);
        //     }
        //     else
        //     {
        //         noAdsButton.Hide(immediately: true);
        //     }
        // }

        // private void HideAdButton(bool immediately = false)
        // {
        //     if(AdsManager.IsForcedAdEnabled())
        //     {
        //         noAdsButton.Hide(immediately);
        //     }
        // }

        // private void ForceAdPurchased()
        // {
        //     noAdsButton.Hide(true);
        // }

        #endregion

        #region Buttons

        public void SettingsButton()
        {
            Debug.Log("CLICK SETTINGS");
            UIController.ShowPage<UISettings>();

            // AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        }

        public void NoAdButton()
        {
            UIController.ShowPage<UINoAdsPopUp>();

            // AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        }

        // public void StoreButton()
        // {
        //     UIController.ShowPage<UIStore>();

        //     AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        // }

        // public void AddCoinsButton()
        // {
        //     UIController.ShowPage<UIStore>();

        //     AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        // }

        // private void OnSkinsStoreButtonClicked()
        // {
        //     UIController.ShowPage<UISkinStore>();

        //     AudioController.PlaySound(AudioController.AudioClips.buttonSound);
        // }

        #endregion
    }

}
