using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        private Animator _animator;
        
        private readonly int _speed = Animator.StringToHash("Speed");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _animator.SetFloat(_speed, Mathf.Abs(joystick.Direction.magnitude));
        }
    }
}