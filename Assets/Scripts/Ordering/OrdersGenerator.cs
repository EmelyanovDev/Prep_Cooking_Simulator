using Sounds;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ordering
{
    public class OrdersGenerator : MonoBehaviour
    {
        private OrdersDisplay _ordersDisplay;
        private Order[] _orders;

        private static OrdersGenerator _instance;
        
        public static OrdersGenerator Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<OrdersGenerator>();
                return _instance;
            }
        }
        
        private void Awake()
        {
            _orders = Resources.LoadAll<Order>("Orders");
            _ordersDisplay = OrdersDisplay.Instance;
        }

        public Order CreateNewOrder()
        {
            Order newOrder = _orders[Random.Range(0, _orders.Length)];
            _ordersDisplay.DisplayNewOrder(newOrder);

            return newOrder;
        }
    }
}
