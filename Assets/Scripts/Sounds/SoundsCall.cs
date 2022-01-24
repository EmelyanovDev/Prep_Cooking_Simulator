using UnityEngine;

namespace Sounds
{
    public class SoundsCall : MonoBehaviour
    {
        [SerializeField] private AudioSource bellSound;
        [SerializeField] private AudioSource tapSound;
        
        private static SoundsCall _instance;

        public static SoundsCall Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<SoundsCall>();
                return _instance;
            }
        }

        public void PlayBell() => bellSound.Play();

        public void PlayTap() => tapSound.Play();
    }
}
