using GoogleMobileAds.Api;
using UnityEngine;

namespace Advertisement
{
    public class Interstitial : MonoBehaviour
    {
        [SerializeField] private string interstitialID = "ca-app-pub-5504475350859040~6098416598";

        private InterstitialAd _interstitial;

        private void Awake()
        {
            _interstitial = new InterstitialAd(interstitialID);
            AdRequest adRequest = new AdRequest.Builder().Build();
            _interstitial.LoadAd(adRequest);
        }

        public bool TryShowInterstitial()
        {
            if (_interstitial.IsLoaded())
            {
                _interstitial.Show();
                return true;
            }
            return false;
        }
    }
}