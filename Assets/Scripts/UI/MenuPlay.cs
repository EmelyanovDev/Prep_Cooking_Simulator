using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    [RequireComponent(typeof(Button))]
    
    public class MenuPlay : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;
        private Button _thisButton;

        private void Awake()
        {
            _thisButton = GetComponent<Button>();
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
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
