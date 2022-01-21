using System.Collections.Generic;
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
            OrderView view = FindViewByOrder(order);
            _orderViews.Remove(view);
            Destroy(view.gameObject);
        }

        private OrderView FindViewByOrder(Order order)
        {
            foreach (var orderView in _orderViews)
            {
                if (orderView.ThisOrder == order)
                    return orderView;
            }

            return null;
        }
    }
}
