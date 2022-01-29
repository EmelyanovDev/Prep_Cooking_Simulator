using Sounds;
using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Meat : CollectingItem, IFrying
    {
        [SerializeField] private float preparationSpeed = 10f;
        [SerializeField] private float coloringMultiplier = 0.004f;
        
        private MeshRenderer _renderer;
        private SoundsCall _soundsCall;
        private bool _soundPlayed;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _soundsCall = SoundsCall.Instance;
        }

        public void Frying()
        {
            cookingQuality += preparationSpeed * Time.deltaTime;
            if (cookingQuality >= 100 && !_soundPlayed)
            {
                _soundsCall.PlayBell();
                _soundPlayed = true;
            }

            var color = _renderer.material.color;
            float coloringValue = preparationSpeed * coloringMultiplier * Time.deltaTime;
            color.r -= coloringValue;
            color.b -= coloringValue;
            color.g -= coloringValue;
            _renderer.material.color = color;
        }
    }
}
