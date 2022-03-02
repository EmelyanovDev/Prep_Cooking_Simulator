using System.Linq;
using UnityEngine;

namespace Items
{
    public class BoxesHub : MonoBehaviour
    {
        private ItemsBox[] _itemsContainers;
        
        private static BoxesHub _instance;

        public static BoxesHub Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<BoxesHub>();
                return _instance;
            }
        }

        private void Awake()
        {
            _itemsContainers = FindObjectsOfType<ItemsBox>();
        }

        public void SupplyItems(Item suppliedItem, int itemsCount)
        {
            var container = FindContainerByType(suppliedItem);

            container.DeliverySelfItems(itemsCount);
        }

        private ItemsBox FindContainerByType(Item findingItem)
        {
            return _itemsContainers.FirstOrDefault(itemsContainer => itemsContainer.Item == findingItem);
        }
    }
}