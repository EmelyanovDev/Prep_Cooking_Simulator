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

        private Quaternion _rotateQuaternion;
        private Rigidbody _rigidbody;
        private Transform _selfTransform;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _selfTransform = GetComponent<Transform>();
            _rotateQuaternion = Quaternion.Euler(rotation);
        }

        private void FixedUpdate()
        {
            Vector3 moving = joystick.Direction * moveSpeed * Time.deltaTime;
            _rigidbody.velocity = _rotateQuaternion * moving;

            Vector3 indicatorPosition = _selfTransform.position + _rotateQuaternion * joystick.Direction * motionIndicatorSpeed;
            indicatorPosition.y = motionIndicator.position.y;
            motionIndicator.position = indicatorPosition;
        }
    }
}