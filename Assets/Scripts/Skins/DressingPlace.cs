using UnityEngine;

namespace Skins
{
    public class DressingPlace : MonoBehaviour
    {
        private Transform _selfTransform;
        private GameObject _skinObject;

        private void Awake()
        {
            _selfTransform = GetComponent<Transform>();
        }

        public void SetSkin(GameObject skinObject)
        {
            if (_skinObject != null)
                Destroy(_skinObject);

            if (skinObject != null)
                _skinObject = Instantiate(skinObject, _selfTransform);
        }
    }
}