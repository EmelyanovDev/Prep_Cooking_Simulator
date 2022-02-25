using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        private Animator _animator;
<<<<<<< HEAD
        
        private readonly int _speed = Animator.StringToHash("Speed");
=======
        private readonly int _isWalk = Animator.StringToHash("IsWalk");
>>>>>>> parent of dd61c95 (Try to made blend tree)

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