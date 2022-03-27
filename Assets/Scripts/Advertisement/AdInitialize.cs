using GoogleMobileAds.Api;
using UnityEngine;

namespace Advertisement
{
    public class AdInitialize : MonoBehaviour
    {
        private void Awake()
        {
            MobileAds.Initialize(initializationStatus => { });
        }
    }
}