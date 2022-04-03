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
        [SerializeField] private AudioSource pickSound;
        [SerializeField] private AudioSource putSound;
        [SerializeField] private AudioSource skinSound;
        [SerializeField] private AudioSource errorSound;
        [SerializeField] private AudioSource actionSound;
         
        public AudioSource BellSound => bellSound;
        public AudioSource TapSound => tapSound;
        public AudioSource PickSound => pickSound;
        public AudioSource PutSound => putSound;
        public AudioSource SkinSound => skinSound;
        public AudioSource ErrorSound => errorSound;
        public AudioSource ActionSound => actionSound;

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
