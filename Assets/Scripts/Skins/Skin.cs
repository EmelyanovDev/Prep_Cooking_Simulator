using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "Skin", menuName = "New Skin")]
    public class Skin : ScriptableObject
    {
        [SerializeField] private GameObject skinModel;
        [SerializeField] private Sprite skinIcon;
        [SerializeField] private int skinPrice;

        public GameObject SkinModel => skinModel;
        public Sprite SkinIcon => skinIcon;
        public int SkinPrice => skinPrice;
    }
}
