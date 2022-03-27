using System.Collections.Generic;
using Items;
using UI;
using UnityEngine;

namespace Client
{
    public static class OrderEvaluation
    {
        public static float EvaluateOrder(Item item, Items.ItemType[] orderRecipe)
        {
            List<Item> orderComponents = new List<Item> {item};
            AddChildComponents(orderComponents, item);

            int count = Mathf.Min(orderComponents.Count, orderRecipe.Length);

            float result = 0f;
            
            for (int i = 0; i < count; i++)
                if (orderComponents[i].ItemType == orderRecipe[i])
                    result += orderComponents[i].CookingQuality;
            
            result /= orderRecipe.Length;
            Rating.Instance.RatingUpdate(result);

            return result;
        }
        
        private static void AddChildComponents(List<Item> orderComponents, Item parentItem)
        {
            if (parentItem.ChildItems.Count == 0) return;

            foreach (var childItem in parentItem.ChildItems)
            {
                orderComponents.Add(childItem);
                
                if(childItem.ChildItems.Count > 0)
                    AddChildComponents(orderComponents, childItem);
            }
        }
    }
}