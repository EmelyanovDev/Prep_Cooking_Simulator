using System;
using System.Collections.Generic;
using System.Linq;
using Sounds;
using UnityEngine;

namespace Ordering
{
    public class OrdersDisplay : MonoBehaviour
    {
        [SerializeField] private OrderView orderTemplate;
        [SerializeField] private Transform ordersContainer;

        private List<OrderView> _orderViews = new List<OrderView>();
        
        private SoundsCall _soundsCall;
        private AudioSource _errorSound;
        private AudioSource _orderSound;

        private static OrdersDisplay _instance;

        public static OrdersDisplay Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<OrdersDisplay>();
                return _instance;
            }
        }

        private void Awake()
        {
            _soundsCall = SoundsCall.Instance;
            _errorSound = _soundsCall.ErrorSound;
            _orderSound = _soundsCall.ActionSound;
        }

        public void DisplayNewOrder(Order order)
        {
            OrderView newOrder = Instantiate(orderTemplate, ordersContainer);
            newOrder.Init(order);
            _orderViews.Add(newOrder);

            _orderSound.Play();
        }

        public void DeleteOrder(Order order)
        {
            OrderView view = FindOrderView(order);
            _orderViews.Remove(view);
            Destroy(view.gameObject);
            
            _errorSound.Play();
        }

        private OrderView FindOrderView(Order order)
        {
            return _orderViews.FirstOrDefault(orderView => orderView.ThisOrder == order);
        }
    }
}
