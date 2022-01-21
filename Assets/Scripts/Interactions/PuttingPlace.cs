using System.Linq;
using Items;
using UnityEngine;

namespace Interactions
{
    public class PuttingPlace : MonoBehaviour
    {
        protected PuttingPoint[] PuttingPoints;
        
        private void Awake() => PuttingPoints = transform.parent.GetComponentsInChildren<PuttingPoint>();

        public bool CanCollectItem(bool pointEmptyCondition)
        {
            return PuttingPoints.Any(puttingPoint => puttingPoint.CollectingItem == null == pointEmptyCondition);
        }

        public Vector3 GetItemPoint(CollectingItem collectingItem)
        {
            foreach (var puttingPoint in PuttingPoints)
            {
                if (puttingPoint.CollectingItem != null) continue;
                
                puttingPoint.SetCollectingItem(collectingItem);
                return puttingPoint.transform.position;
            }

            return Vector3.zero;
        }

        public CollectingItem TakeItem()
        {
            foreach (var puttingPoint in PuttingPoints)
            {
                if (puttingPoint.CollectingItem == null) continue;
                
                var collectingItem = puttingPoint.CollectingItem;
                puttingPoint.SetCollectingItem(null);
                return collectingItem;
            }

            return null;
        }

    }
}
