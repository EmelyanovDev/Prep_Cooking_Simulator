using UnityEngine;

namespace Items.Childs
{
    public class MoneyBill : Item
    {
        [SerializeField] private int billCost;

        public int BillCost => billCost;
    }
}