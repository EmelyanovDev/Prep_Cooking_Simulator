using Items;
using Player;
using UI;
using UnityEngine;

namespace Supply
{
    public class SuppliesHub : MonoBehaviour
    {
        private Money _money;
        private ContainersHub _containersHub;
        
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
            _containersHub = ContainersHub.Instance;
        }

        public void TryBuySupply(Supply supply)
        {
            if (_money.MoneyCount < supply.SupplyPrice) return;
            
            _money.ChangeMoneyCount(-supply.SupplyPrice);
            _containersHub.SupplyItems(supply.SuppliedProduct, supply.ProductsCount);
        }
    }
}