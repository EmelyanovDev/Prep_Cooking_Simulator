using UnityEngine;
using UnityEngine.UI;

namespace Ordering
{
    public class OrderView : MonoBehaviour
    {
        [SerializeField] private Image orderIcon;
        [SerializeField] private Image orderTimer;
        
        private float _orderDuration;
        private float _currentTime;
        private Order _thisOrder;

        public Order ThisOrder => _thisOrder;

        public void Init(Order thisOrder)
        {
            _thisOrder = thisOrder;
            orderIcon.sprite = _thisOrder.OrderIcon;
            _orderDuration = _thisOrder.OrderDuration;
            _currentTime = _orderDuration;
        }

        private void Update()
        {
            _currentTime -= Time.deltaTime;
            orderTimer.fillAmount = _currentTime / _orderDuration;
        }
    }
}
