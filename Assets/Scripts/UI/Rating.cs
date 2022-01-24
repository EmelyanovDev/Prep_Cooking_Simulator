using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class Rating : MonoBehaviour
    {
        [SerializeField] private Vector2 endPosition;
        [SerializeField] private float movingSpeed;
        [SerializeField] private float standingTime;

        private Slider _ratingSlider;
        private RectTransform _selfTransform;
        private Vector2 _startPosition;

        private static Rating _instance;

        public static Rating Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Rating>();
                return _instance;   
            }
        }

        private void Awake()
        {
            _ratingSlider = GetComponent<Slider>();
            _selfTransform = GetComponent<RectTransform>();
            _startPosition = _selfTransform.anchoredPosition;
        }

        public void RatingUpdate(float value)
        {
            StartCoroutine(MoveTo(0, endPosition));
            
            _ratingSlider.value = value;
            
            StartCoroutine(MoveTo(standingTime, _startPosition));
        }

        private IEnumerator MoveTo(float delay, Vector2 targetPosition)
        {
            yield return new WaitForSeconds(delay);
            
            while (_selfTransform.anchoredPosition != targetPosition)
            {
                _selfTransform.anchoredPosition = Vector2.MoveTowards(_selfTransform.anchoredPosition, targetPosition,
                    movingSpeed * Time.deltaTime);

                yield return new WaitForFixedUpdate();
            }
        }
    }
}    