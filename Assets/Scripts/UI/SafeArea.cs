using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(RectTransform))]
    
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _safeArea;
        private Vector2 minAnchor;
        private Vector2 maxAnchor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            _safeArea = Screen.safeArea;
            minAnchor = _safeArea.position;
            maxAnchor = minAnchor + _safeArea.size;

            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAnchor.x /= Screen.width;
            maxAnchor.y /= Screen.height;

            _rectTransform.anchorMin = minAnchor;
            _rectTransform.anchorMax = maxAnchor;
        }
    }
}
