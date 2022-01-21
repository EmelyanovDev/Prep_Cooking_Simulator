using System.Linq;
using UnityEngine;

namespace Items
{
    public class ContainersHub : MonoBehaviour
    {
        private ItemsContainer[] _itemsContainers;
        
        private static ContainersHub _instance;

        public static ContainersHub Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<ContainersHub>();
                return _instance;
            }
        }

        private void Awake() => _itemsContainers = FindObjectsOfType<ItemsContainer>();

        public void SupplyItems(CollectingItem suppliedItem, int itemsCount)
        {
            var container = FindContainerByType(suppliedItem);

            container.DeliveryItems(itemsCount);
        }

        private ItemsContainer FindContainerByType(CollectingItem findingItem) =>
            _itemsContainers.FirstOrDefault(itemsContainer => itemsContainer.CollectingItem == findingItem);
    }
}