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

        public bool OnPrefabSaving()
        {
            Component[] cachedPageElements = GetComponentsInChildren(typeof(IUIPageElement));

            if (registeredElements == null || registeredElements.Length != cachedPageElements.Length)
            {
                registeredElements = cachedPageElements;
                return true;
            }

            for(int i = 0; i < registeredElements.Length; i++)
            {
                if (registeredElements[i] == null)
                {
                    registeredElements = cachedPageElements;

                    return true;
                }
            }

            for (int i = 0; i < cachedPageElements.Length; i++)
            {
                if(!ReferenceEquals(registeredElements[i], cachedPageElements[i]))
                {
                    registeredElements = cachedPageElements;

                    return true;
                }
            }

            return false;
        }

        public void OnSceneSaving()
        {
            throw new System.NotImplementedException();
        }
    }

}
