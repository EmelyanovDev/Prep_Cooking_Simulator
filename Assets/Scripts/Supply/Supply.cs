﻿using Items;
using UnityEngine;

namespace Supply
{
    [CreateAssetMenu(fileName = "Supply", menuName = "New Supply", order = 0)]
    public class Supply : ScriptableObject
    {
        [SerializeField] private CollectingItem suppliedProduct;
        [SerializeField] private int productsCount;
        [SerializeField] private int supplyPrice;
        [SerializeField] private Sprite productIcon;

        public CollectingItem SuppliedProduct => suppliedProduct;
        public int ProductsCount => productsCount;
        public int SupplyPrice => supplyPrice;
        public Sprite ProductIcon => productIcon;
    }
}