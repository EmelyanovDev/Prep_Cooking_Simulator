using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerMoney : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private string moneyKey = "MoneyCount";
        [SerializeField] private int moneyCount;

        public int MoneyCount => moneyCount;
    
        private static PlayerMoney _instance;

        public static PlayerMoney Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<PlayerMoney>();
                return _instance;
            }
        }

        private void Awake()
        {
            if (PlayerPrefs.HasKey(moneyKey))
            {
                moneyCount = PlayerPrefs.GetInt(moneyKey);
                moneyText.text = moneyCount.ToString();
            }
        }

        public void ChangeMoneyCount(int changeCount)
        {
            moneyCount += changeCount;
            moneyText.text = moneyCount.ToString();
        
            PlayerPrefs.SetInt(moneyKey, moneyCount);
        }
    }
}
