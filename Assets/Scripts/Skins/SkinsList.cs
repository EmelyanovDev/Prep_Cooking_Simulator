using UnityEngine;

namespace Skins
{
    public class SkinsList : MonoBehaviour
    {
        [SerializeField] private Transform skinsContainer;
        [SerializeField] private SkinView skinTemplate;
        
        private Skin[] _skins;
        private const string SkinsPath = "Skins";

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