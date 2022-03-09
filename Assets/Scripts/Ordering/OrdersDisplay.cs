using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ordering
{
    public class OrdersDisplay : MonoBehaviour
    {
        [SerializeField] private OrderView orderTemplate;
        [SerializeField] private Transform ordersContainer;

        private List<OrderView> _orderViews = new List<OrderView>();

        private static OrdersDisplay _instance;

        public static OrdersDisplay Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<OrdersDisplay>();
                return _instance;
            }
        }

        public void DisplayNewOrder(Order order)
        {
            OrderView newOrder = Instantiate(orderTemplate, ordersContainer);
            newOrder.Init(order);
            _orderViews.Add(newOrder);
        }

        public void DeleteOrder(Order order)
        {
            OrderView view = FindOrderView(order);
            _orderViews.Remove(view);
            Destroy(view.gameObject);
        }

        private OrderView FindOrderView(Order order)
        {
            return _orderViews.FirstOrDefault(orderView => orderView.ThisOrder == order);
        }
    }
}
