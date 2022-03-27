using System;
using UnityEngine;

namespace Sounds
{
    public class SoundsCall : MonoBehaviour
    {
        [SerializeField] private AudioSource bellSound;
        [SerializeField] private AudioSource tapSound;
        [SerializeField] private AudioSource fryingSound;
        [SerializeField] private AudioSource washingSound;
        
        public AudioSource BellSound => bellSound;
        public AudioSource TapSound => tapSound;

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

        public void TryFrying()
        {
            if (fryingSound.isPlaying == false)
            {
                fryingSound.Play();
            }
        }

        public void TryWashing()
        {
            if (washingSound.isPlaying == false)
            {
                washingSound.Play();
            }
        }
    }
}
