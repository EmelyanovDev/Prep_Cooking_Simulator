using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    [RequireComponent(typeof(Button))]
    
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private int sceneIndex;
        private Button _thisButton;

        private void Awake()
        {
            _thisButton = GetComponent<Button>();
            _thisButton.onClick.AddListener(LoadLevel);
        }

        private void LoadLevel() => SceneManager.LoadScene(sceneIndex);
    }
}
