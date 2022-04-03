using Items;
using Sounds;
using UI;
using UnityEngine;

namespace Supply
{
    public class SuppliesHub : MonoBehaviour
    {
        private Money _money;
        private BoxesHub _boxesHub;
        
        private SoundsCall _soundsCall;
        private AudioSource _buttonSound;
        private AudioSource _errorSound;
        
        private static SuppliesHub _instance;

        public static SuppliesHub Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SuppliesHub>();
                return _instance;
            }
        }

        private void Awake()
        {
            _money = Money.Instance;
            _boxesHub = BoxesHub.Instance;
            
            _soundsCall = SoundsCall.Instance;
            _buttonSound = _soundsCall.ActionSound;
            _errorSound = _soundsCall.ErrorSound;
        }

        public void TryBuySupply(Supply supply)
        {
            if (_money.TryChangeMoney(-supply.SupplyPrice) == false)
            {
                _errorSound.Play();
                return;
            }
                
            _buttonSound.Play();
            _boxesHub.SupplyItems(supply.SuppliedProduct, supply.ProductsCount);
        }
    }
}