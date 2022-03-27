using GoogleMobileAds.Api;
using UnityEngine;

namespace Advertisement
{
    public class Rewarded : MonoBehaviour
    {
        [SerializeField] private string rewardedID = "ca-app-pub-3940256099942544/5354046379";

        private RewardedAd _rewarded;

        private void Awake()
        {
            _rewarded = new RewardedAd(rewardedID);
            AdRequest adRequest = new AdRequest.Builder().Build();
            _rewarded.LoadAd(adRequest);
        }

        public bool TryShowRewarded()
        {
            if (_rewarded.IsLoaded())
            {
                _rewarded.Show();
                return true;
            }

            return false;
        }
    }
}