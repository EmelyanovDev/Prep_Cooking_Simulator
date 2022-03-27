using Items;
using Items.Childs;
using UI;
using UnityEngine;

namespace Interactions
{
    public class CashRegister : MonoBehaviour
    {
        [SerializeField] private float destroyDelay;

        private Transform _selfTransform;
        private Money _money;

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
            _money = Money.Instance;
        }

        public Vector3 PutBill(Item moneyBill)
        {
            if(moneyBill is MoneyBill bill)
                _money.TryChangeMoney(bill.BillCost);
            
            Destroy(moneyBill.gameObject, destroyDelay);
            
            return _selfTransform.position;
        }
    }
}