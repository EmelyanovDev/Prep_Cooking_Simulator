using UnityEngine;

namespace Items.Childs
{
    public class MoneyBill : CollectingItem
    {
        [SerializeField] private int billCost;

        public int BillCost => billCost;
    }
}