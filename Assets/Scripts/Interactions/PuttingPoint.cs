using Items;
using UnityEngine;

namespace Interactions
{
    public class PuttingPoint : MonoBehaviour
    {
        private CollectingItem _collectingItem;
        
        public CollectingItem CollectingItem => _collectingItem;

        public void SetCollectingItem(CollectingItem collectingItem) => _collectingItem = collectingItem;
    }
}
