using Skins;
using UnityEngine;

namespace Player
{
    public class PlayerSkin : MonoBehaviour
    {
        [SerializeField] private DressingPlace head;

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
            head.SetSkin(skin.SkinModel);
        }
    }
}