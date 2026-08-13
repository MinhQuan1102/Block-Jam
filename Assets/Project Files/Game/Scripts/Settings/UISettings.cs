using Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BlockJam
{
    public class UISettings : UIPage, IPopupWindow, IPausePopup
    {
        [BoxGroup("References", "References")]
        [SerializeField] Image backgroundImage;
        [BoxGroup("References", "References")]
        [SerializeField] RectTransform panelRectTransform;
        [BoxGroup("References", "References")]
        [SerializeField] RectTransform contentRectTransform;
        public RectTransform ContentRectTransform => contentRectTransform;

        [BoxGroup("Buttons", "Buttons")]
        [SerializeField] Button closeButton;

        private float fadeIntensity;

        public bool IsOpened => canvas.enabled;

        public override void Init()
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
            backgroundImage.AddEvent(EventTriggerType.PointerDown, OnBackgroundClicked);

            fadeIntensity = backgroundImage.color.a;
        }

        public override void PlayShowAnimation()
        {
            // RecalculatePanelSize();

            panelRectTransform.anchoredPosition = Vector2.down * 2000;
            panelRectTransform.DOAnchoredPosition(Vector2.zero, 0.3f, unscaledTime: true).SetEasing(Ease.Type.SineOut);

            backgroundImage.SetAlpha(0f);
            backgroundImage.DOFade(fadeIntensity, 0.3f, unscaledTime: true).OnComplete(() => 
            {
                UIController.OnPageOpened(this);
            });
        }

        public override void PlayHideAnimation()
        {
            panelRectTransform.DOAnchoredPosition(Vector2.down * 2000, 0.3f, unscaledTime: true).SetEasing(Ease.Type.SineIn);

            backgroundImage.DOFade(0f, 0.3f, unscaledTime: true).OnComplete(() =>
            {
                UIController.OnPageClosed(this);
            });
        }

        public void OnCloseButtonClicked()
        {
            // AudioController.PlaySound(AudioController.AudioClips.buttonSound);

            UIController.HidePage<UISettings>();
        }

        private void OnBackgroundClicked(PointerEventData data)
        {
            UIController.HidePage<UISettings>();
        }

    }
}
