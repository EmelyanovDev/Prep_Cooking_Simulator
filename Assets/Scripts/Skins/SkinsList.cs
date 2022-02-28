﻿using UnityEngine;

namespace Skins
{
    public class SkinsList : MonoBehaviour
    {
        [SerializeField] private Transform skinsContainer;
        [SerializeField] private SkinView skinTemplate;
        
        private Skin[] _skins;
        private const string SkinsPath = "Skins";

        private static SkinsList _instance;

        public static SkinsList Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SkinsList>();
                return _instance;
            }
        }

        private void Awake()
        {
            _skins = Resources.LoadAll<Skin>(SkinsPath);

            if(skinsContainer != null)
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