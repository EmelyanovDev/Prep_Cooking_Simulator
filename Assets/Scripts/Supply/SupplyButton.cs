using UnityEngine;
using UnityEngine.UI;

namespace Supply
{
    [RequireComponent(typeof(Button))]
    public class SupplyButton : MonoBehaviour
    {
        [SerializeField] private GameObject deliveryMenu;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(MenuSwitching);

        private void OnDisable() => _button.onClick.RemoveListener(MenuSwitching);

        private void MenuSwitching() => deliveryMenu.SetActive(!deliveryMenu.activeSelf);
    }
}
