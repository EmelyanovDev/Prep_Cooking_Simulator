using UnityEngine;
using GoogleMobileAds.Api;

namespace Advertisement
{
    public class AdInitialize : MonoBehaviour
    {
        private void Awake()
        {
            MobileAds.Initialize(status => { });
        }
    }
}
