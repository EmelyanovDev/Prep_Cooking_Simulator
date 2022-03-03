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

        public void SupplyItems(Item item, int itemsCount)
        {
            var container = FindBoxByType(item);

            container.DeliverySelfItems(itemsCount);
        }

        private ItemsBox FindBoxByType(Item boxItem)
        {
            return _itemsContainers.FirstOrDefault(itemsContainer => itemsContainer.Item == boxItem);
        }
    }
}