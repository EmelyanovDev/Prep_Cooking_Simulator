using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Salad : CollectingItem, IWashing, IFrying
    {
        [SerializeField] private float preparationSpeed = 15f;
        [SerializeField] private float coloringMultiplier = 0.002f;
        
        private MeshRenderer _renderer;

        private void Awake() => _renderer = GetComponent<MeshRenderer>();

        public void Washing()
        {
            if(CookingQuality < 100)
                cookingQuality += preparationSpeed * Time.deltaTime;
            
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
