using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    
    public class ResetButton : MonoBehaviour
    {
        [SerializeField] private GameObject confirmationMenu;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(OnButtonClick);
        
        private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

        private void OnButtonClick() => confirmationMenu.SetActive(!confirmationMenu.activeSelf);
    }
}