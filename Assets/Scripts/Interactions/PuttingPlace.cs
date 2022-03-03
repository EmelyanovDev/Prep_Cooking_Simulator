using System.Linq;
using Items;
using UnityEngine;

namespace Interactions
{
    public class PuttingPlace : MonoBehaviour, IPickItem, IPutItem
    {
        [SerializeField] protected float cookingSpeed = 15f;
        [SerializeField] protected float coloringMultiplier = 0.002f;
        
        protected PuttingPoint[] _puttingPoints;

        private void Awake()
        {
            _puttingPoints = transform.parent.GetComponentsInChildren<PuttingPoint>();
        }

        public Item PickItem()
        {
            foreach (var puttingPoint in _puttingPoints)
            {
                if (puttingPoint.Item == null) continue;
                
                var collectingItem = puttingPoint.Item;
                puttingPoint.SetCollectingItem(null);
                return collectingItem;
            }

            return null;
        }
        
        public bool CanPickItem()
        {
            return _puttingPoints.Any(point => point.Item == null == false);
        }
        
        public Vector3 PutItem(Item item)
        {
            foreach (var puttingPoint in _puttingPoints)
            {
                if (puttingPoint.Item != null) continue;
                
                puttingPoint.SetCollectingItem(item);
                return puttingPoint.transform.position;
            }

            return Vector3.zero;
        }
        
        public bool CanPutItem()
        {
            return _puttingPoints.Any(puttingPoint => puttingPoint.Item == null);
        }
    }
}
