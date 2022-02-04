using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TMP_Text))]
    
    public class Money : MonoBehaviour
    {
        [SerializeField] private string moneyKey = "MoneyCount";
        [SerializeField] private int moneyCount;
        
        private TMP_Text _moneyText;

        public int MoneyCount => moneyCount;
    
        private static Money _instance;

        public static Money Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<Money>();
                return _instance;
            }
        }

        private void Awake()
        {
            _moneyText = GetComponent<TMP_Text>();
            
            if (PlayerPrefs.HasKey(moneyKey))
            {
                moneyCount = PlayerPrefs.GetInt(moneyKey);
                _moneyText.text = moneyCount.ToString();
            }
        }

        public void ChangeMoneyCount(int changeCount)
        {
            moneyCount += changeCount;
            _moneyText.text = moneyCount.ToString();
        
            PlayerPrefs.SetInt(moneyKey, moneyCount);
        }
    }
}
