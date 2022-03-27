using Advertisement;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    
    public class RewardedButton : MonoBehaviour
    {
        [SerializeField] private int rewardCount;
        [SerializeField] private Rewarded rewarded;

        private Money _money;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _money = Money.Instance;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            if (rewarded.TryShowRewarded() == true)
            {
                _money.TryChangeMoney(rewardCount);
                gameObject.SetActive(false);
            }
        }
    }
}