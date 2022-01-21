using System.Collections.Generic;
using System.Linq;
using Client;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Slider))]
    public class Rating : MonoBehaviour
    {
        private Slider _ratingSlider;
        private List<float> _evaluations = new List<float>();

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

        private void Awake() => _ratingSlider = GetComponent<Slider>();

        public void RatingUpdate(float value)
        {
            _evaluations.Add(value);
            
            float evaluation = 0f;
            if(_evaluations.Count != 0)
                evaluation = _evaluations.Sum() / _evaluations.Count;
                
            _ratingSlider.value = evaluation;
        }
    }
}    