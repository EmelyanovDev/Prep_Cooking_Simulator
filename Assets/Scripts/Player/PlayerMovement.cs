﻿using UnityEngine;

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
            Vector3 indicatorPosition = _selfTransform.position + _rotateMultiplier * joystick.Direction * motionIndicatorSpeed;
            indicatorPosition.y = motionIndicator.position.y;
            motionIndicator.position = indicatorPosition;

            if (joystick.Direction == Vector3.zero) return;
            
            Vector3 moving = joystick.Direction * moveSpeed * Time.deltaTime;
            _rigidbody.velocity = _rotateMultiplier * moving;
            
            _selfTransform.forward = _rotateMultiplier * joystick.Direction;
        }
    }
}