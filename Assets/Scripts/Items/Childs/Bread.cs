using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Bread : CollectingItem, IFrying
    {
        [SerializeField] private float coloringSpeed = 0.04f;
        
        private MeshRenderer _renderer;

        private void Awake() => _renderer = GetComponent<MeshRenderer>();

        public void Frying()
        {
            var color = _renderer.material.color;
            float coloringValue = coloringSpeed * Time.deltaTime;
            color.r -= coloringValue;
            color.b -= coloringValue;
            color.g -= coloringValue;
            _renderer.material.color = color;
        }
    }
}
