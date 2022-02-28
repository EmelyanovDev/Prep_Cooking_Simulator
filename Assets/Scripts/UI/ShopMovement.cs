using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ShopMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 endPosition;
        [SerializeField] private float moveSpeed;
        [SerializeField] private Button shopButton;
        
        private Vector2 _startPosition;
        private Vector2 _targetPosition;
        
        private RectTransform _selfTransform;
        
        private void Awake()
        {
            _selfTransform = GetComponent<RectTransform>();
            
            _startPosition = _selfTransform.anchoredPosition;
            _targetPosition = _startPosition;
        }

        private void Update()
        {
            if (_selfTransform.anchoredPosition != _targetPosition)
            {
                float move = moveSpeed * Time.deltaTime;
                _selfTransform.anchoredPosition = Vector2.MoveTowards(_selfTransform.anchoredPosition, _targetPosition, move);
            }
        }

        private void OnEnable()
        {
            shopButton.onClick.AddListener(SwitchTarget);
        }
        
        private void OnDisable()
        {
            shopButton.onClick.RemoveListener(SwitchTarget);
        }

        private void SwitchTarget()
        {
            if (_targetPosition == _startPosition)
                _targetPosition = endPosition;
            else if (_targetPosition == endPosition)
                _targetPosition = _startPosition;
        }
    }
}
