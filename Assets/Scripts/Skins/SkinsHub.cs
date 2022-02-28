using Player;
using SaveSystem;
using UI;
using UnityEngine;

namespace Skins
{
    public class SkinsHub : MonoBehaviour
    {
        private PlayerSkin _playerSkin;
        private Money _money;

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
            _money = Money.Instance;
            _playerSkin = PlayerSkin.Instance;
        }

        public void TrySetSkin(Skin skin)
        {
            var saveSystem = new JsonSaveSystem();

            if (saveSystem.Load().Skins.Contains(skin))
            {
                _playerSkin.PutOnSkin(skin);
            }
            else if (_money.TryReduceMoney(skin.SkinPrice))
            {
                BuySkin(skin, saveSystem);
                
                _playerSkin.PutOnSkin(skin);
            }
            else
            {
                print("Not enough money & skin not bought");
            }
        }

        private void BuySkin(Skin skin, JsonSaveSystem saveSystem)
        {
            var data = saveSystem.Load();
            data.Skins.Add(skin);
            switch (skin.SkinType)
            {
                case SkinType.Head:
                    data.HeadSkin = skin;
                    break;
                case SkinType.Face:
                    data.FaceSkin = skin;
                    break;
                case SkinType.Body:
                    data.BodySkin = skin;
                    break;
            }
            saveSystem.Save(data);
        }
    }
}