using UI;
using UnityEngine;

namespace Skins
{
    public class SkinsHub : MonoBehaviour
    {
        private Stars _stars;
        
        private static SkinsHub _instance;

        public static SkinsHub Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SkinsHub>();
                return _instance;
            }
        }

        private void Awake()
        {
            _stars = Stars.Instance;
        }

        public void OnSkinClick(Skin skin)
        {
            if (PlayerPrefs.HasKey(skin.SkinId.ToString()))
            {
                
            }
            else
            {
                if (_stars.StarsCount < skin.SkinPrice)
                    return;
            
                _stars.ChangeStarsCount(skin.SkinPrice);
                PlayerPrefs.SetInt(skin.SkinId.ToString(), 1);
            }
        }
    }
}