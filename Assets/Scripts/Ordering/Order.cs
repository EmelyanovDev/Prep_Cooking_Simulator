using Items;
using UnityEngine;

namespace Ordering
{
    [CreateAssetMenu(fileName = "Order", menuName = "New Order")]
    public class Order : ScriptableObject
    {
        [SerializeField] private Sprite orderIcon;
        [SerializeField] private ItemsTypes[] orderRecipe;
        [SerializeField] private float orderDuration;
        
        public Sprite OrderIcon => orderIcon;
        public ItemsTypes[] OrderRecipe => orderRecipe;
        public float OrderDuration => orderDuration;
    }
}
