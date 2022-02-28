using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Interactions
{
    public class KitchenTable : MonoBehaviour
    {
        [SerializeField] private Transform collectingPoint;
        [SerializeField] private float itemsStep;
        
        [SerializeField] private List<CollectingItem> _containedItems = new List<CollectingItem>();

        public Vector3 PutItem(CollectingItem collectingItem)
        {
            Vector3 collectingPosition = collectingPoint.position + itemsStep * _containedItems.Count * Vector3.up;
            _containedItems.Add(collectingItem);
            AddChildComponents(collectingItem);

            if (_containedItems.Count <= 1) return collectingPosition;
            
            collectingItem.transform.parent = _containedItems[0].transform;
            
            if (collectingItem != _containedItems[0]) 
                _containedItems[0].AddChildItem(collectingItem);
            
            return collectingPosition;
        }

        public bool HasContainedItem() => _containedItems.Count > 0;

        public CollectingItem GetItem()
        {
            CollectingItem returningItem = _containedItems[0];
            _containedItems = new List<CollectingItem>();

            return returningItem;
        }

        private void AddChildComponents(CollectingItem parentItem)
        {
            if (parentItem.ChildItems.Count == 0) return;

            foreach (var childItem in parentItem.ChildItems)
            {
                _containedItems.Add(childItem);
                
                if(childItem.ChildItems.Count > 0)
                    AddChildComponents(childItem);
            }
        }
    }
}
