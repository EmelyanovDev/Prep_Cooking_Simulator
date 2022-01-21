using UnityEngine;

namespace Interactions.Dirt
{
    public class DirtPoint : MonoBehaviour
    {
        private bool _isBusy;
        private Transform _selfTransform;

        public bool IsBusy => _isBusy;

        private void Awake() => _selfTransform = GetComponent<Transform>();

        public Vector3 GetPosition() => _selfTransform.position;
        
        public void SetBusy(bool condition) => _isBusy = condition;
    }
}