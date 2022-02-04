using Items;
using UnityEngine;

namespace Interactions
{
    public class Trashcan : MonoBehaviour
    {
        [SerializeField] private float destroyDelay;
        
        private Transform _trashPoint;

        private void Awake()
        {
            _trashPoint = transform.parent;
        }

        public Vector3 GetTrashPoint(CollectingItem collectingItem)
        {
            Destroy(collectingItem.gameObject, destroyDelay);
            
            return _trashPoint.position;
        }
    }
}
