using UnityEngine;

namespace Skins
{
    [CreateAssetMenu(fileName = "Skin", menuName = "New Skin")]
    public class Skin : ScriptableObject
    {
        [SerializeField] private GameObject skinModel;
        [SerializeField] private Sprite skinIcon;
        [SerializeField] private SkinType skinType;
        [SerializeField] private int skinPrice;
        [SerializeField] private int skinID;
        
        public GameObject SkinModel => skinModel;
        public Sprite SkinIcon => skinIcon;
        public SkinType SkinType => skinType;
        public int SkinPrice => skinPrice;
        public int SkinId => skinID;
    }
}
