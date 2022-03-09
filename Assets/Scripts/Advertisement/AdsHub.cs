using UnityEngine;
using GoogleMobileAds.Api;

namespace Advertisement
{
    public class AdsHub : MonoBehaviour
    {
        private InterstitialAd _interstitialAd;

        private const string IntersitialID = "ca-app-pub-3940256099942544/1033173712";
        
        public void OnEnable()
        {
            _interstitialAd = new InterstitialAd(IntersitialID);
            AdRequest adRequest = new AdRequest.Builder().Build();
        }
    }
}