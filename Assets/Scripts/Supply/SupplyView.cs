using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Supply
{
    [RequireComponent(typeof(Button))]
    public class SupplyView : MonoBehaviour
    {
        [SerializeField] private Image supplyImage;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text productsCountText;

        private Supply _thisSupply;
        
        public Supply ThisSupply => _thisSupply;
        
        public void Init(Supply thisSupply)
        {
            _thisSupply = thisSupply;
            
            supplyImage.sprite = _thisSupply.ProductIcon;
            priceText.text = _thisSupply.SupplyPrice.ToString();
            productsCountText.text = _thisSupply.ProductsCount.ToString();
        }
    }
}