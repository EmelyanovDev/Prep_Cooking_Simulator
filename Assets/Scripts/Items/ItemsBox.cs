using System.Collections.Generic;
using Interactions;
using UnityEngine;

namespace Items
{
    public class ItemsBox : MonoBehaviour, IPickItem, IPutItem
    {
        [SerializeField] private Item item;
        [SerializeField] private float itemsStep;
        [SerializeField] private float itemsSpeed;
        [SerializeField] private int startItemsCount;

        private List<Item> _containedItems = new List<Item>();
        private Transform _selfTransform;

        public Item Item => item;

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
            var item = Instantiate(this.item, _selfTransform.position, Quaternion.identity);
            Vector3 itemPosition = _selfTransform.position + itemsStep * _containedItems.Count * Vector3.up;
            StartCoroutine(item.MoveToPosition(itemPosition, itemsSpeed));
            _containedItems.Add(item);
        }
        
        public Item PickItem()
        {
            var item = _containedItems[_containedItems.Count - 1];
            _containedItems.Remove(item);
            
            return item;
        }
        
        public bool CanPickItem()
        {
            return _containedItems.Count > 0;
        }

        public Vector3 PutItem(Item putItem)
        {
            Vector3 itemPosition = _selfTransform.position + itemsStep * _containedItems.Count * Vector3.up;
            _containedItems.Add(putItem);
            
            return itemPosition;
        }
        
        public bool CanPutItem()
        {
            return true;
        }
    }
}