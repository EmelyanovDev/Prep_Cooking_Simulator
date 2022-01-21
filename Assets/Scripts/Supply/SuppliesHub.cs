using Items;
using Player;
using UnityEngine;

namespace Supply
{
    public class SuppliesHub : MonoBehaviour
    {
        private PlayerMoney _playerMoney;
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
            _playerMoney = PlayerMoney.Instance;
            _containersHub = ContainersHub.Instance;
        }

        public void TryBuySupply(Supply supply)
        {
            if (_playerMoney.MoneyCount < supply.SupplyPrice) return;
            
            _playerMoney.ChangeMoneyCount(-supply.SupplyPrice);
            _containersHub.SupplyItems(supply.SuppliedProduct, supply.ProductsCount);
        }
    }
}