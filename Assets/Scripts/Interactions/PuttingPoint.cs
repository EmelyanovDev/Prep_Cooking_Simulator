using Items;
using UnityEngine;

namespace Interactions
{
    public class PuttingPoint : MonoBehaviour
    {
        private Item _item;
        
        public Item Item => _item;

        public void SetCollectingItem(Item item) => _item = item;
    }
}
