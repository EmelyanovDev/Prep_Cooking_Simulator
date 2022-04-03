using Sounds;
using UnityEngine;
using UnityEngine.UI;

namespace Supply
{
    [RequireComponent(typeof(Button))]
    public class SuppliesListButton : MonoBehaviour
    {
        [SerializeField] private GameObject suppliesMenu;

        private Button _button;
        private AudioSource _buttonSound;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _buttonSound = SoundsCall.Instance.ActionSound;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(MenuSwitching);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(MenuSwitching);
        }

        private void MenuSwitching()
        {
            _buttonSound.Play();
            suppliesMenu.SetActive(!suppliesMenu.activeSelf);
        }
    }
}
