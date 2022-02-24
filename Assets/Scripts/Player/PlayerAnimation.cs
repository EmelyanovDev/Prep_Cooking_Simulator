using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        private Animator _animator;
        private readonly int _isWalk = Animator.StringToHash("IsWalk");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _animator.SetBool(_isWalk, joystick.Direction != Vector3.zero);
        }
    }
}