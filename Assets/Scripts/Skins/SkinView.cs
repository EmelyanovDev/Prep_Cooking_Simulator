using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skins
{
    public class SkinView : MonoBehaviour
    {
        [SerializeField] private Image skinIcon;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private string pricePrefix = "Price: ";

        private Skin _thisSkin;

        public Skin ThisSkin => _thisSkin;

        public void Init(Skin thisSkin, bool isBought)
        {
            _thisSkin = thisSkin;
            
            skinIcon.sprite = _thisSkin.SkinIcon;
            
            if(_thisSkin.WriteText == true && isBought == false)
                priceText.text = pricePrefix + _thisSkin.SkinPrice;
        }

        public void DeactivateText()
        {
            priceText.gameObject.SetActive(false);
        }
    }
}