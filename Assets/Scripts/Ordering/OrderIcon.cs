using UnityEngine;

namespace Ordering
{
    public class OrderIcon : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationVector;
        
        private Transform _selfTransform;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        private void Start()
        {
            Vector3 inspectorRotation = _selfTransform.rotation.eulerAngles - _selfTransform.parent.rotation.eulerAngles + rotationVector;
            _selfTransform.rotation = Quaternion.Euler(inspectorRotation);
        }
    }
}