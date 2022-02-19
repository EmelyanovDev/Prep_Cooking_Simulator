using TMPro;
using UnityEngine;

namespace UI
{
    public class  Stars : MonoBehaviour
    {
        [SerializeField] private string startKey = "StarsCount";
        [SerializeField] private int starsCount;
        
        [SerializeField] private TMP_Text _starsText;

        public int StarsCount => starsCount;
    
        private static Stars _instance;

        public static Stars Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<Stars>();
                return _instance;
            }
        }

        private void Awake()
        {
            if (PlayerPrefs.HasKey(startKey))
            {
                starsCount = PlayerPrefs.GetInt(startKey);
                _starsText.text = starsCount.ToString();
            }
        }

        public void ChangeStarsCount(int changeCount)
        {
            starsCount += changeCount;
            _starsText.text = starsCount.ToString();
        
            PlayerPrefs.SetInt(startKey, starsCount);
        }
    }
}
