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

        [SerializeField] private string headKey;
        [SerializeField] private string faceKey;
        [SerializeField] private string bodyKey;

        private SkinsList _skinsList;

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

        private void Awake()
        {
            _skinsList = SkinsList.Instance;
        }

        private void Start()
        {
            if (PlayerPrefs.HasKey(headKey))
            {
                SetSkin(_skinsList.GetSkinByID(PlayerPrefs.GetInt(headKey)));
            }

            if (PlayerPrefs.HasKey(faceKey))
            {
                SetSkin(_skinsList.GetSkinByID(PlayerPrefs.GetInt(faceKey)));
            }

            if (PlayerPrefs.HasKey(bodyKey))
            {
                SetSkin(_skinsList.GetSkinByID(PlayerPrefs.GetInt(bodyKey)));
            }
        }

        public void SetSkin(Skin skin)
        {
            switch (skin.SkinType)
            {
                case SkinType.Head:
                    SaveSkin(head, skin, headKey);
                    break;
                case SkinType.Face:
                    SaveSkin(face, skin, faceKey);
                    break;
                case SkinType.Body:
                    SaveSkin(body, skin, bodyKey);
                    break;
            }
        }

        private void SaveSkin(DressingPlace place, Skin skin, string key)
        {
            place.SetSkin(skin.SkinModel);
            PlayerPrefs.SetInt(key, skin.SkinID);
        }
    }
}