using Sounds;
using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Salad : Item, IWashing
    {
        [SerializeField] protected ParticleSystem cookingEffect;
        
        private MeshRenderer _renderer;
        private SoundsCall _soundsCall;
        private bool _soundPlayed;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            _soundsCall = SoundsCall.Instance;
        }

        public void Washing(float cookingSpeed, float coloringMultiplier)
        {
            if (cookingQuality >= 100)
            {
                if (_soundPlayed == false)
                {
                    _soundsCall.PlayTap();
                    _soundPlayed = true;
                }
                return;
            }
            
            cookingQuality += cookingSpeed * Time.deltaTime;
            if(cookingEffect.isPlaying == false)
                cookingEffect.Play();
            
            var color = _renderer.material.color;
            float coloringValue = cookingSpeed * coloringMultiplier * Time.deltaTime;
            color.r += coloringValue;
            color.b += coloringValue;
            color.g += coloringValue;
            _renderer.material.color = color;
        }
    }
}
