using Items;
using UnityEngine;

namespace Interactions
{
    public class Trashcan : MonoBehaviour, IPutItem
    {
        [SerializeField] private float destroyDelay;
        
        private Transform _trashPoint;

        private void Awake()
        {
            _trashPoint = transform.parent;
        }

        public Vector3 PutItem(Item item)
        {
            Destroy(item.gameObject, destroyDelay);
            
            return _trashPoint.position;
        }
        
        public bool CanPutItem()
        {
            return true;
        }
    }
}
