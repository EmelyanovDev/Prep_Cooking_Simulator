using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactions;
using Items;
using Ordering;
using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    [RequireComponent(typeof(PlaceInteraction))]
    public class ClientsPlaceEvaluation : MonoBehaviour
    {
        [SerializeField] private Item dirtyPallet;
        [SerializeField] private SpriteRenderer orderIcon;
        [SerializeField] private float evaluateDelay;

        private BoxesHub _boxesHub;
        private MoneyGenerator _moneyGenerator;
        private OrdersDisplay _ordersDisplay;
        private Order _thisOrder;
        private ItemType[] _orderRecipe;
        [SerializeField] private List<Item> _orderComponents;
        private Transform _placePoint;
        private bool _recipeIsCreated;

        public UnityAction FreeUpSpace;
        
        public bool RecipeIsCreated => _recipeIsCreated;

        private void Awake()
        {
            _placePoint = GetComponent<PlaceInteraction>().PlacePoint;

            _ordersDisplay = OrdersDisplay.Instance;
            _boxesHub = BoxesHub.Instance;
            _moneyGenerator = MoneyGenerator.Instance;
        }

        public void SetNewOrder(Order order)
        {
            _thisOrder = order;
            _orderRecipe = _thisOrder.OrderRecipe;
            orderIcon.sprite = _thisOrder.OrderIcon;
            orderIcon.gameObject.SetActive(true);

            StartCoroutine(FreeUpPlace(order.OrderDuration));
            _recipeIsCreated = true;
        }

        public IEnumerator TryEvaluateOrder(Item putItem)
        {
            yield return new WaitForSeconds(evaluateDelay);

            float result = OrderEvaluation.EvaluateOrder(putItem, _orderRecipe);
            
            Destroy(putItem.gameObject);
            
            CreatePallet();
            StartCoroutine(_moneyGenerator.CreateMoney(_placePoint.position, result));
            StartCoroutine(FreeUpPlace(0));
        }

        private void CreatePallet()
        {
            int palletsCount = _orderComponents.Count(orderComponent => orderComponent.ItemType == ItemType.Pallet);
            _boxesHub.SupplyItems(dirtyPallet, palletsCount);
        }
        
        private IEnumerator FreeUpPlace(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            _ordersDisplay.DeleteOrder(_thisOrder);
            _recipeIsCreated = false;
            orderIcon.gameObject.SetActive(false);
            FreeUpSpace?.Invoke();
        }
    }
}