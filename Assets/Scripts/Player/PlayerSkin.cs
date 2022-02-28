using System;
using Skins;
using UnityEngine;

namespace Player
{
    public class PlayerSkin : MonoBehaviour
    {
        [SerializeField] private DressingPlace head;
        [SerializeField] private DressingPlace face;
        [SerializeField] private DressingPlace body;

        private static PlayerSkin _instance;

        public static PlayerSkin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<PlayerSkin>();
                return _instance;
            }
        }
        
        public void PutOnSkin(Skin skin)
        {
            switch (skin.SkinType)
            {
                case SkinType.Head:
                    SetSkin(head, skin);
                    break;
                case SkinType.Face:
                    SetSkin(face, skin);
                    break;
                case SkinType.Body:
                    SetSkin(body, skin);
                    break;
            }
        }
        
        private void SetSkin(DressingPlace place, Skin skin)
        {
            place.SetSkin(skin.SkinModel);
        }
    }
}