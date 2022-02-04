using Sounds;
using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Salad : CollectingItem, IWashing, IFrying
    {
        [SerializeField] private float preparationSpeed = 15f;
        [SerializeField] private float coloringMultiplier = 0.002f;
        
        private MeshRenderer _renderer;
        private SoundsCall _soundsCall;
        private bool _soundPlayed;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _soundsCall = SoundsCall.Instance;
        }

        public void Washing()
        {
            if(CookingQuality <= 100)
                cookingQuality += preparationSpeed * Time.deltaTime;
            if (cookingQuality >= 100 && _soundPlayed == false)
            {
                _soundsCall.PlayTap();
                _soundPlayed = true;
            }
            
            var color = _renderer.material.color;
            float coloringValue = preparationSpeed * coloringMultiplier * Time.deltaTime;
            color.r += coloringValue;
            color.b += coloringValue;
            color.g += coloringValue;
            _renderer.material.color = color;
        }

        public void Frying()
        {
            var color = _renderer.material.color;
            float coloringValue = preparationSpeed * coloringMultiplier * Time.deltaTime;
            color.r -= coloringValue;
            color.b -= coloringValue;
            color.g -= coloringValue;
            _renderer.material.color = color;
        }
    }
}
