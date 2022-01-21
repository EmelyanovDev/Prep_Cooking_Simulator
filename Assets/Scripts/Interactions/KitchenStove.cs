using Items;

namespace Interactions
{
    public class KitchenStove : PuttingPlace
    {
        private void Update()
        {
            foreach (var puttingPoint in PuttingPoints)
                if(puttingPoint.CollectingItem is IFrying cookingItem)
                    cookingItem.Frying();
        }
    }
}