using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BlockJam
{
    public class UINoAdsPopUp : UIPage, IPopupWindow, IPausePopup
    {
        [SerializeField] Image backgroundImage;
        [SerializeField] UIScaleAnimation panelScalable; 
        [SerializeField] Button smallCloseButton;
        public bool IsOpened => canvas.enabled;

        private UIFadeAnimation backFade;

        public override void Init()
        {
            backFade = new UIFadeAnimation(gameObject);

            backgroundImage.AddEvent(EventTriggerType.PointerClick, OnBackgroundClicked);

            smallCloseButton.onClick.AddListener(OnCloseButtonClicked);

            backFade.Hide(immediately: true);
            panelScalable.Hide(immediately: true);
        }

        public override void PlayShowAnimation()
        {
            backFade.Show(0.2f, onCompleted: () =>
            {
                panelScalable.Show(immediately: false, duration: 0.3f);
            });

            UIController.OnPageOpened(this);

            // AdsManager.HideBanner();
        }

        public override void PlayHideAnimation()
        {
            backFade.Hide(0.2f);
            panelScalable.Hide(immediately: false, duration: 0.4f, onCompleted: () =>
            {
                UIController.OnPageClosed(this);
            });

            // AdsManager.ShowBanner();
        }

        private void OnCloseButtonClicked()
        {
            // AudioController.PlaySound(AudioController.AudioClips.buttonSound);

            UIController.HidePage(this);
        }

        private void OnBackgroundClicked(PointerEventData data)
        {
            UIController.HidePage(this);
        }
    }
}