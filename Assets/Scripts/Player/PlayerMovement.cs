using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]

    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 100f;
        [SerializeField] private float motionIndicatorSpeed = 0.3f;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Transform motionIndicator;
        [SerializeField] private Vector3 rotation;
        
        private float turnSmoothVelocity;

        private Quaternion _rotateMultiplier;
        private Rigidbody _rigidbody;
        private Transform _selfTransform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _selfTransform = GetComponent<Transform>();

            _rotateMultiplier = Quaternion.Euler(rotation);
        }

        private void FixedUpdate()
        {
            Vector3 moving = joystick.Direction * moveSpeed * Time.deltaTime;
            _rigidbody.velocity = _rotateMultiplier * moving;

            if (joystick.Direction != Vector3.zero)
            {
                _selfTransform.forward = _rotateMultiplier * joystick.Direction;
                print(_selfTransform.forward);
            }

            Vector3 indicatorPosition = _selfTransform.position + _rotateMultiplier * joystick.Direction * motionIndicatorSpeed;
            indicatorPosition.y = motionIndicator.position.y;
            motionIndicator.position = indicatorPosition;
        }
    }
}