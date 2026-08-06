using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public abstract class UIPage : MonoBehaviour, ISceneSavingCallback
    {
        // [Hide]
        [SerializeField] Component[] registeredElements;
        protected bool isPageDisplayed;
        public bool IsPageDisplayed { get => isPageDisplayed; set => isPageDisplayed = value; }
        protected Canvas canvas;
        public Canvas Canvas => canvas;

        protected GraphicRaycaster graphicRaycaster;
        public GraphicRaycaster GraphicRaycaster => graphicRaycaster;
        private string defaultName;

        private IUIPageElement[] pageElements;

        protected bool isCached;
        public bool IsCached => isCached;

        public void CacheComponents()
        {
            defaultName = name;

            canvas = GetComponent<Canvas>();
            graphicRaycaster = GetComponent<GraphicRaycaster>();
        }

        public void OnSceneSaving()
        {
            throw new System.NotImplementedException();
        }
    }

}
