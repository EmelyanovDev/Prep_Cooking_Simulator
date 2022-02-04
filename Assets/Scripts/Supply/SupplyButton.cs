using Skins;
using UnityEngine;
using UnityEngine.UI;

namespace Supply
{
    [RequireComponent(typeof(SupplyView))]
    [RequireComponent(typeof(Button))]
    
    public class SupplyButton : MonoBehaviour
    {
        private SupplyView _supplyView;
        private Button _supplyButton;
        
        private SuppliesHub _suppliesHub;

        private void Awake()
        {
            _supplyView = GetComponent<SupplyView>();
            _supplyButton = GetComponent<Button>();
            
            _suppliesHub = SuppliesHub.Instance;
        }

        private void OnEnable()
        {
            _supplyButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _supplyButton.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _suppliesHub.TryBuySupply(_supplyView.ThisSupply);
        }
    }
}