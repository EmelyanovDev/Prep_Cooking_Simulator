using System;
using UnityEngine;

namespace Skins
{
    public class SkinsList : MonoBehaviour
    {
        [SerializeField] private Transform skinsContainer;
        [SerializeField] private SkinView skinTemplate;
        
        private Skin[] _skins;

        private void Awake()
        {
            _skins = Resources.LoadAll<Skin>("Skins");

            foreach (var skin in _skins)
                CreateSkin(skin);
        }

        private void CreateSkin(Skin skin)
        {
            var view = Instantiate(skinTemplate, skinsContainer);
            view.Init(skin);
        }
    }
}