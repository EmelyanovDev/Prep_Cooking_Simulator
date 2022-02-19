using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ItemsContainer : MonoBehaviour
    {
        [SerializeField] private CollectingItem collectingItem;
        [SerializeField] private float itemsStep;
        [SerializeField] private float itemsSpeed;
        [SerializeField] private int startItemsCount;

        private List<CollectingItem> _containedItems = new List<CollectingItem>();
        private Transform _selfTransform;

        public CollectingItem CollectingItem => collectingItem;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            for (int i = 0; i < startItemsCount; i++)
                CreateItem();
        }

        public void DeliverySelfItems(int itemsCount)
        {
            for (int i = 0; i < itemsCount; i++)
                CreateItem();
        }

        private void CreateItem()
        {
            var item = Instantiate(collectingItem, _selfTransform.position, Quaternion.identity);
            Vector3 itemPosition = _selfTransform.position + itemsStep * _containedItems.Count * Vector3.up;
            StartCoroutine(item.MoveToPosition(itemPosition, itemsSpeed));
            _containedItems.Add(item);
        }

        public bool CanPickItem() => _containedItems.Count > 0;
        
        public CollectingItem GetItem()
        {
            var item = _containedItems[_containedItems.Count - 1];
            _containedItems.Remove(item);
            
            return item;
        }

        public Vector3 PutItem(CollectingItem collectingItem)
        {
            Vector3 itemPosition = _selfTransform.position + itemsStep * _containedItems.Count * Vector3.up;
            _containedItems.Add(collectingItem);
            
            return itemPosition;
        }
    }
}

