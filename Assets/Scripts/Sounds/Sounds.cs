using UnityEngine;

namespace Sounds
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioSource bellSound;
        [SerializeField] private AudioSource tapSound;
        
        private static Sounds _instance;

        public static Sounds Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType<Sounds>();
                return _instance;
            }
        }

        public void PlayBell() => bellSound.Play();

        public void PlayTap() => tapSound.Play();
    }
}
