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
        private JsonSaveSystem _saveSystem;

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
            _saveSystem = new JsonSaveSystem();
        }

        private void Start()
        {
            var headSkin = _saveSystem.Load().headSkin;
            
            if(headSkin != null)
                PutOnSkin(headSkin);
        }

        public void TrySetSkin(Skin skin)
        {
            if (_saveSystem.Load().boughtSkins.Contains(skin) || TryBuySkin(skin))
            {
                PutOnSkin(skin);
            }
            else
            {
                Debug.Log("Not enough money & skin not bought");
            }
        }

        private bool TryBuySkin(Skin skin)
        {
            if (_money.TryReduceMoney(skin.SkinPrice) == false) return false;
            
            var data = _saveSystem.Load();
            data.boughtSkins.Add(skin);
            _saveSystem.Save(data);
            return true;
        }

        private void PutOnSkin(Skin skin)
        {
            var data = _saveSystem.Load();
            data.headSkin = skin;
            _saveSystem.Save(data);
            
            _playerSkin.PutOnSkin(skin);
        }
    }
}