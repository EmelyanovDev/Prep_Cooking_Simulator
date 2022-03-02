using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Interactions
{
    public class KitchenTable : MonoBehaviour, IPickItem, IPutItem
    {
        [SerializeField] private Transform collectingPoint;
        [SerializeField] private float itemsStep;
        
        [SerializeField] private List<Item> _containedItems = new List<Item>();
        
        public Vector3 PutItem(Item item)
        {
            Vector3 collectingPosition = collectingPoint.position + itemsStep * _containedItems.Count * Vector3.up;
            _containedItems.Add(item);
            AddChildComponents(item);

            if (_containedItems.Count <= 1) return collectingPosition;
            
            item.transform.parent = _containedItems[0].transform;
            
            if (item != _containedItems[0]) 
                _containedItems[0].AddChildItem(item);
            
            return collectingPosition;
        }
        
        public bool CanPutItem()
        {
            return true;
        }

        public Item PickItem()
        {
            Item returningItem = _containedItems[0];
            _containedItems = new List<Item>();

            return returningItem;
        }
        
        public bool CanPickItem()
        {
            return _containedItems.Count > 0;
        }

        private void AddChildComponents(Item parentItem)
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
