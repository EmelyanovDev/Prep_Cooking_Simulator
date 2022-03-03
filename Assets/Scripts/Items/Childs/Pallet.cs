using UnityEngine;

namespace Items.Childs
{
    public class Pallet : Item, IWashing
    {
        [SerializeField] private MeshRenderer dirtStain;
        [SerializeField] private float dirtTransparent;

        private void Awake()
        {
            var materialColor = dirtStain.material.color;
            materialColor.a = dirtTransparent;
            dirtStain.material.color = materialColor;
        }

        public void Washing(float washingSpeed, float coloringMultiplier)
        {
            if (CookingQuality >= 100) return;
            
            cookingQuality += washingSpeed * Time.deltaTime;
            
            var color = dirtStain.material.color;
            color.a -= washingSpeed * coloringMultiplier * Time.deltaTime;
            dirtStain.material.color = color;
        }
    }
}
