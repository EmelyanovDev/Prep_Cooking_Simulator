using System.Collections;
using Items.Childs;
using UnityEngine;

namespace Interactions
{
    public class MoneyGenerator : MonoBehaviour
    {
        [SerializeField] private MoneyBill moneyBill;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float createDelay;
        
        private CashRegister _cashRegister;
        
        private static MoneyGenerator _instance;

        public static MoneyGenerator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<MoneyGenerator>();
                return _instance;
            }
        }

        private void Awake()
        {
            _cashRegister = CashRegister.Instance;
        }

        public IEnumerator CreateMoney(Vector3 startPosition, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(createDelay);
                
                var bill = Instantiate(moneyBill, startPosition, Quaternion.identity);
                var position = _cashRegister.PutBill(bill);
                StartCoroutine(bill.MoveToPosition(position, moveSpeed));
            }
            
            yield return null;
        }
    }
}