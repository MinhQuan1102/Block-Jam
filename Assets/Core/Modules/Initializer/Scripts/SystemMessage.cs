using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core
{
    [RequireComponent(typeof(Canvas), typeof(CanvasScaler))]
    public class SystemMessage : MonoBehaviour
    {
        private static SystemMessage floatingMessage;
        [Header("Messages")]
        [SerializeField] RectTransform messagePanelRectTransform;
        [SerializeField] TextMeshProUGUI messageText;

        [Header("Loading")]
        [SerializeField] GameObject loadingPanelObject;
        [SerializeField] TextMeshProUGUI loadingStatusText;
        [SerializeField] RectTransform loadingIconRectTransform;
        private TweenCase animationTweenCase;
        private CanvasGroup messagePanelCanvasGroup;

        public void Init()
        {
            if (floatingMessage != null) return;

            floatingMessage = this;
            CanvasScaler canvasScaler = gameObject.GetComponent<CanvasScaler>();
            canvasScaler.MatchSize();

            messagePanelCanvasGroup = gameObject.AddComponent<CanvasGroup>();
            messageText.AddEvent(EventTriggerType.PointerClick, (data) => OnPanelClick());

            loadingPanelObject.SetActive(false);
            messagePanelRectTransform.gameObject.SetActive(false);
        }

        private void OnPanelClick()
        {
            
        }
    }
}