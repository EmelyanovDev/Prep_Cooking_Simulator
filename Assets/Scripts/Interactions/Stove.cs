using Items;

namespace Interactions
{
    public class Stove : PuttingPlace
    {
        private void Update()
        {
            foreach (var puttingPoint in _puttingPoints)
            {
                if (puttingPoint.Item is IFrying cookingItem)
                {
                    cookingItem.Frying(cookingSpeed, coloringMultiplier);
                }
            }
        }
    }
}