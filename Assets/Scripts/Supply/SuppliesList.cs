using UnityEngine;

namespace Supply
{
    public class SuppliesList : MonoBehaviour
    {
        [SerializeField] private SupplyView supplyTemplate;
        [SerializeField] private Transform suppliesContainer;
        
        private Supply[] _supplies;
        private const string SuppliesPath = "Supplies";

        private void Awake()
        {
            _supplies = Resources.LoadAll<Supply>(SuppliesPath);
            
            foreach (var supply in _supplies)
                CreateSupply(supply);
        }

        private void CreateSupply(Supply supply)
        {
            var view = Instantiate(supplyTemplate, suppliesContainer);
            view.Init(supply);
        }
    }
}