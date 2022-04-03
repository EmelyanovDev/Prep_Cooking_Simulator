using Player;
using SaveSystem;
using Sounds;
using UI;
using UnityEngine;

namespace Skins
{
    public class SkinsHub : MonoBehaviour
    {
        private PlayerSkin _playerSkin;
        private Money _money;
        private JsonSaveSystem _saveSystem;
        private SoundsCall _soundsCall;
        private AudioSource _skinSound;
        private AudioSource _errorSound;

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
            _soundsCall = SoundsCall.Instance;
            
            _saveSystem = new JsonSaveSystem();

            _skinSound = _soundsCall.SkinSound;
            _errorSound = _soundsCall.ErrorSound;
        }

        private void Start()
        {
            var headSkin = _saveSystem.Load().headSkin;
            
            if(headSkin != null)
                PutOnSkin(headSkin);
        }

        public bool TrySetSkin(Skin skin)
        {
            if (_saveSystem.Load().boughtSkins.Contains(skin) || TryBuySkin(skin))
            {
                _skinSound.Play();
                PutOnSkin(skin);
                return true;
            }
            else
            {
                _errorSound.Play();
                return false;
            }
        }

        private bool TryBuySkin(Skin skin)
        {
            if (_money.TryChangeMoney(-skin.SkinPrice) == false) return false;
            
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