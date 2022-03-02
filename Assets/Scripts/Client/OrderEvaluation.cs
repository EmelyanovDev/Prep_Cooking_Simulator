using System.Collections.Generic;
using Items;
using UI;
using UnityEngine;

namespace Client
{
    public class OrderEvaluation : MonoBehaviour
    {
        [SerializeField] private float evaluateDelay = 2f;
        
        private List<Item> _orderComponents;

        private Rating _rating;

        private void Awake()
        {
            _rating = Rating.Instance;
        }

        public void EvaluateOrder(Item item, ItemType[] orderRecipe)
        {
            _orderComponents = new List<Item> {item};
            AddChildComponents(item);

            var count = Mathf.Max(_orderComponents.Count, orderRecipe.Length);

            float finalPercentage = 0f;
            
            for (int i = 0; i < count; i++)
                if (_orderComponents[i].ItemType == orderRecipe[i])
                    finalPercentage += _orderComponents[i].CookingQuality;
            
            finalPercentage /= orderRecipe.Length;

            _rating.RatingUpdate(finalPercentage);
            Destroy(_orderComponents[0].gameObject);
            //CreatePallet();
            //CreateMoney();
            //StartCoroutine(FreeUpPlace(0));
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