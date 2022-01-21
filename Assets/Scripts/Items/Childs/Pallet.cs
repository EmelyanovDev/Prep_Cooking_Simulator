using UnityEngine;

namespace Items.Childs
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Pallet : CollectingItem, IFrying, IWashing
    {
        [SerializeField] private MeshRenderer dirtStain;
        [SerializeField] private float dirtTransparent;
        [SerializeField] private float washingSpeed;
        [SerializeField] private float coloringSpeed = 0.04f;

        private MeshRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<MeshRenderer>();
            
            var materialColor = dirtStain.material.color;
            materialColor.a = dirtTransparent;
            dirtStain.material.color = materialColor;
        }

        public void Frying()
        {
            var color = _renderer.material.color;
            float coloringValue = coloringSpeed * Time.deltaTime;
            color.r -= coloringValue;
            color.b -= coloringValue;
            color.g -= coloringValue;
            _renderer.material.color = color;
        }


        public void Washing()
        {
            if(CookingQuality < 100)
                cookingQuality += washingSpeed * coloringSpeed * Time.deltaTime;
            
            var color = dirtStain.material.color;
            color.a -= coloringSpeed * Time.deltaTime;
            dirtStain.material.color = color;
        }
    }
}
