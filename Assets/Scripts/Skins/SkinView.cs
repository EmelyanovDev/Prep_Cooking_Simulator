using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skins
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private Image skinIcon;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private string pricePrefix;

        private Skin _thisSkin;

        public void Init(Skin thisSkin)
        {
            _thisSkin = thisSkin;

            skinIcon.sprite = _thisSkin.SkinIcon;
            priceText.text = pricePrefix + _thisSkin.SkinPrice;
        }
    }
}