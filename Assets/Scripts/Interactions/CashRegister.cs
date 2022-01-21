using Items;
using Items.Childs;
using Player;
using UnityEngine;

namespace Interactions
{
    public class CashRegister : MonoBehaviour
    {
        [SerializeField] private float destroyDelay;

        private Transform _selfTransform;
        private PlayerMoney _playerMoney;

        private static CashRegister _instance;

        public static CashRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<CashRegister>();
                return _instance;
            }
        }

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
            _playerMoney = PlayerMoney.Instance;
        }

        public Vector3 PutBill(CollectingItem moneyBill)
        {
            Destroy(moneyBill.gameObject, destroyDelay);
            
            if(moneyBill is MoneyBill bill)
                _playerMoney.ChangeMoneyCount(bill.BillCost);
            
            return _selfTransform.position;
        }
    }
}