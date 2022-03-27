using GoogleMobileAds.Api;
using UnityEngine;

namespace Advertisement
{
    public class Banner : MonoBehaviour
    {
        [SerializeField] private string bannerID = "ca-app-pub-3940256099942544/6300978111";

        private BannerView _banner;

        private void Awake()
        {
            _banner = new BannerView(bannerID, AdSize.Banner, AdPosition.Bottom);
            AdRequest adRequest = new AdRequest.Builder().Build();
            _banner.LoadAd(adRequest);
        }

        private void Start()
        {
            ShowBanner();
        }

        private void ShowBanner()
        {
            _banner.Show();
        }
    }
}