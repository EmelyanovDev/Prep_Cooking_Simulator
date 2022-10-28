using UnityEngine;

public class PickIndicator : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffet;

    private Transform _selfTransform;

    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _selfTransform.position = target.position + targetOffet;
    }
}
