using System;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] [Range(0f, 10f)] private float deltaInterpolate = 1f;
    
    private Transform _selfTransform;
    private Vector3 _startPosition;

    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        if (target == null) throw new NullReferenceException();
        
        _startPosition = _selfTransform.position - target.position;
    }

    private void FixedUpdate()
    {
        var position = target.transform.position + _startPosition;
        var interpolate = Vector3.Lerp(_selfTransform.position, position, deltaInterpolate * Time.deltaTime);
        _selfTransform.position = interpolate;
    }
}
