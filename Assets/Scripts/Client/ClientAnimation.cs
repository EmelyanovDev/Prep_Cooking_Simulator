using UnityEngine;

namespace Client
{
    [RequireComponent(typeof(Animator))]

    public class ClientAnimation : MonoBehaviour
    {
        private Transform _selfTransform;
        private Animator _animator;
        private Vector3 _previousPosition;
        private float _speed;
        
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
            
            _speed = Mathf.Abs(Vector3.Distance(_previousPosition, position));
            _animator.SetBool(_isWalk, _speed != 0);
            
            _previousPosition = position;
        }
    }
}