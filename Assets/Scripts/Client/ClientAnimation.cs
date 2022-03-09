using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(Animator))]

    public class ClientAnimation : MonoBehaviour
    {
        private Transform _selfTransform;
        private Animator _animator;
        private Vector3 _previousPosition;

        private readonly int _isWalk = Animator.StringToHash("IsWalk");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _selfTransform = GetComponent<Transform>();
            
            _previousPosition = _selfTransform.position;
        }

        private void FixedUpdate()
        {
            var position = _selfTransform.position;
            
            float distance = Mathf.Abs(Vector3.Distance(_previousPosition, position));
            bool isMoving = distance != 0;
            _animator.SetBool(_isWalk, isMoving);
            
            _previousPosition = position;
        }
    }
}