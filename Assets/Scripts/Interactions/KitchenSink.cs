using Items;

namespace Interactions
{
    public class KitchenSink : PuttingPlace
    {
        private void Update()
        {
            foreach (var puttingPoint in PuttingPoints)
            {
                if(puttingPoint.CollectingItem is IWashing cookingItem)
                    cookingItem.Washing();
            }
                
        }
    }
}