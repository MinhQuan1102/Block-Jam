using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    [Serializable]
    public class CurrencyUIPanelSimple : MonoBehaviour
    {
        [SerializeField] CurrencyType currencyType;

        [Space]
        [SerializeField] bool updateOnChange = true;
        [SerializeField] bool useFormattedAmount = true;

        [Space]
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] Image icon;
        [SerializeField] Button addButton;

        public string Text { get => text.text; set => text.text = value; }
        public Sprite Icon { get => icon.sprite; set => icon.sprite = value; }

        public Image Image => icon;
        public Button AddButton => addButton;

        private Currency currency;
        public Currency Currency => currency;
        
        private RectTransform rectTransformRef;
        public RectTransform RectTransform => rectTransformRef;
    }
    
}
