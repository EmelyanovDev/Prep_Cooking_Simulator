using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public abstract class CollectingItem : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] protected float cookingQuality;
        
        private float _collectSpeed;
        private Transform _selfTransform;
        private Transform _targetTransform;
        [SerializeField] private List<CollectingItem> _childItems = new List<CollectingItem>();

        public ItemType ItemType => itemType;
        public float CookingQuality => cookingQuality;
        public List<CollectingItem> ChildItems => _childItems;

        private void FixedUpdate()
        {
            if (_targetTransform == null) return;

            if (transform.position != _targetTransform.position)
                transform.position = Vector3.Lerp(transform.position, _targetTransform.position, _collectSpeed * Time.deltaTime);
        }
        

        public void SetTargetTransform(Transform target, float speed)
        {
            _collectSpeed = speed;
            _targetTransform = target;
        }

        public IEnumerator MoveToPosition(Vector3 position, float moveSpeed)
        {
            _targetTransform = null;
            _selfTransform = GetComponent<Transform>();
            
            while (_selfTransform.position != position && _targetTransform == null)
            {
                _selfTransform.position = Vector3.MoveTowards(_selfTransform.position, position, moveSpeed * Time.deltaTime);
                yield return new WaitForFixedUpdate();
            }
        }

        public void AddChildItem(CollectingItem childItem) => _childItems.Add(childItem);
    }
}
