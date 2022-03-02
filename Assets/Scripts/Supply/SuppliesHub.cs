using Items;
using UI;
using UnityEngine;

namespace Supply
{
    public class SuppliesHub : MonoBehaviour
    {
        private Money _money;
        private BoxesHub _boxesHub;
        
        private static SuppliesHub _instance;

        public static SuppliesHub Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SuppliesHub>();
                return _instance;
            }
        }

        private void Awake()
        {
            _money = Money.Instance;
            _boxesHub = BoxesHub.Instance;
        }

        public void TryBuySupply(Supply supply)
        {
            if (_money.TryReduceMoney(supply.SupplyPrice) == false)
                return;
            
            _boxesHub.SupplyItems(supply.SuppliedProduct, supply.ProductsCount);
        }
    }
}