using UnityEngine;
using UnityEngine.UI;

namespace Skins
{
    [RequireComponent(typeof(SkinView))]
    [RequireComponent(typeof(Button))]
    
    public class SkinButton : MonoBehaviour
    {
        private SkinView _skinView;
        private Button _thisButton;
        private SkinsHub _skinsHub;

        private void Awake()
        {
            _skinView = GetComponent<SkinView>();
            _thisButton = GetComponent<Button>();
            
            _skinsHub = SkinsHub.Instance;
        }

        private void OnEnable()
        {
            _thisButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _thisButton.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _skinsHub.TrySetSkin(_skinView.ThisSkin);
        }
    }
}