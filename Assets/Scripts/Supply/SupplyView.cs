using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Supply
{
    [RequireComponent(typeof(Button))]
    public class SupplyView : MonoBehaviour
    {
        [SerializeField] private Supply thisSupply;
        [SerializeField] private Image supplyImage;
        [SerializeField] private TMP_Text priceText;
        [SerializeField] private TMP_Text productsCountText;

        private Button _button;
        private SuppliesHub _suppliesHub;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _suppliesHub = SuppliesHub.Instance;
            
            supplyImage.sprite = thisSupply.ProductIcon;
            priceText.text = thisSupply.SupplyPrice.ToString();
            productsCountText.text = thisSupply.ProductsCount.ToString();
        }

        private void OnEnable() => _button.onClick.AddListener(TryBuySupply);

        private void OnDisable() => _button.onClick.RemoveListener(TryBuySupply);

        private void TryBuySupply() => _suppliesHub.TryBuySupply(thisSupply);
    }
}