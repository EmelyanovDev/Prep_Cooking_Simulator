using UnityEngine;
using UnityEngine.UI;

namespace Skins
{
    [RequireComponent(typeof(Button))]
    
    public class SkinsListButton : MonoBehaviour
    {
        [SerializeField] private GameObject buttons;
        [SerializeField] private GameObject skinsList;
        
        private Button _thisButton;

        private void Awake()
        {
            _thisButton = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _thisButton.onClick.AddListener(ActiveSwitching);
        }

        private void OnDisable()
        {
            _thisButton.onClick.RemoveListener(ActiveSwitching);
        }

        private void ActiveSwitching()
        {
            skinsList.SetActive(!skinsList.activeSelf);
            buttons.SetActive(!buttons.activeSelf);
        }
    }
}