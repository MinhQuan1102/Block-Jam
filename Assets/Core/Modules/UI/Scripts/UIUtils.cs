using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public static class UIUtils
    {
        public static void MatchSize(this CanvasScaler canvasScaler)
        {
            canvasScaler.matchWidthOrHeight = ((float)Screen.width / Screen.height) > (9f / 16f) ? 1.0f : 0.0f;
        }
    }
}