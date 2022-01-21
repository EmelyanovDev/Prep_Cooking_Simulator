using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Bacon : CollectingItem, IFrying
    {
        [SerializeField] private float preparationSpeed = 10f;
        [SerializeField] private float coloringMultiplier = 0.004f;
        
        private MeshRenderer _renderer;

        private void Awake() => _renderer = GetComponent<MeshRenderer>();

        public void Frying()
        {
            cookingQuality += preparationSpeed * Time.deltaTime;

            var color = _renderer.material.color;
            float coloringValue = preparationSpeed * coloringMultiplier * Time.deltaTime;
            color.r -= coloringValue;
            color.b -= coloringValue;
            color.g -= coloringValue;
            _renderer.material.color = color;
        }
    }
}
