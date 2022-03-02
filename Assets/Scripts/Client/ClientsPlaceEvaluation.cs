using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interactions;
using Items;
using Ordering;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    [RequireComponent(typeof(ClientsPlace))]
    public class ClientsPlaceEvaluation : MonoBehaviour
    {
        [SerializeField] private Item dirtyPallet;
        [SerializeField] private SpriteRenderer orderIcon;
        [SerializeField] private float evaluateDelay;

        private BoxesHub _boxesHub;
        private MoneyGenerator _moneyGenerator;
        private OrdersDisplay _ordersDisplay;
        private Rating _rating;
        private Order _thisOrder;
        private ItemType[] _orderRecipe;
        [SerializeField] private List<Item> _orderComponents;
        private Transform _placeTrasform;
        private float _finalPercentage;
        private bool _recipeIsCreated;
        
        public UnityAction FreeUpSpace;
        
        public bool RecipeIsCreated => _recipeIsCreated;

        private void Awake()
        {
            _placeTrasform = GetComponent<ClientsPlace>().PlacePoint;

            _ordersDisplay = OrdersDisplay.Instance;
            _boxesHub = BoxesHub.Instance;
            _moneyGenerator = MoneyGenerator.Instance;
            _rating = Rating.Instance;
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
            _orderComponents = new List<Item> {putItem};
            AddChildComponents(putItem);

            var count = _orderComponents.Count;
            if (count > _orderRecipe.Length)
                count = _orderRecipe.Length;
            
            for (int i = 0; i < count; i++)
                if (_orderComponents[i].ItemType == _orderRecipe[i])
                    _finalPercentage += 100 - Mathf.Abs(_orderComponents[i].CookingQuality - 100); //при пережарке её качество приготовления падает, а не растёт
            
            _finalPercentage /= _orderRecipe.Length;

            yield return new WaitForSeconds(evaluateDelay);
            
            _rating.RatingUpdate(_finalPercentage);
            Destroy(_orderComponents[0].gameObject);
            CreatePallet();
            CreateMoney();
            StartCoroutine(FreeUpPlace(0));
        }

        private void CreatePallet()
        {
            int palletsCount = _orderComponents.Count(orderComponent => orderComponent.ItemType == ItemType.Pallet);
            _boxesHub.SupplyItems(dirtyPallet, palletsCount);
        }

        private void CreateMoney()
        {
            int moneyCount = 0;
            if (_finalPercentage > 70)
                moneyCount++;
            if (_finalPercentage > 80)
                moneyCount++;
            if (_finalPercentage > 90)
                moneyCount++;
            
            StartCoroutine(_moneyGenerator.CreateMoney(_placeTrasform.position, moneyCount));
        }

        private IEnumerator FreeUpPlace(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            _ordersDisplay.DeleteOrder(_thisOrder);
            _recipeIsCreated = false;
            orderIcon.gameObject.SetActive(false);
            FreeUpSpace?.Invoke();
        }

        private void AddChildComponents(Item parentItem)
        {
            if (parentItem.ChildItems.Count == 0) return;

            foreach (var childItem in parentItem.ChildItems)
            {
                _orderComponents.Add(childItem);
                
                if(childItem.ChildItems.Count > 0)
                    AddChildComponents(childItem);
            }
        }
    }
}