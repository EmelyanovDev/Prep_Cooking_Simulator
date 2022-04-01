using System.Linq;
using SaveSystem;
using UnityEngine;

namespace Skins
{
    public class SkinsList : MonoBehaviour
    {
        [SerializeField] private Transform skinsContainer;
        [SerializeField] private SkinView skinTemplate;
        
        private Skin[] _skins;
        private Skin[] _boughtSkins;
        private const string SkinsPath = "Skins";

        private void Awake()
        {
            _boughtSkins = new JsonSaveSystem().Load().boughtSkins.ToArray();
            _skins = Resources.LoadAll<Skin>(SkinsPath);

            if (skinsContainer != null)
            {
                foreach (var skin in _skins)
                {
                    CreateSkin(skin);
                }
            }
        }

        private void CreateSkin(Skin skin)
        {
            var view = Instantiate(skinTemplate, skinsContainer);
            bool isBought = _boughtSkins.Contains(skin);
            view.Init(skin, isBought);
        }
    }
}