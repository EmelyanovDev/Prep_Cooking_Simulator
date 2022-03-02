using Items;

namespace Interactions
{
    public class Sink : PuttingPlace
    {
        private void Update()
        {
            foreach (var puttingPoint in _puttingPoints)
            {
                if (puttingPoint.Item is IWashing cookingItem)
                {
                    cookingItem.Washing(cookingSpeed, coloringMultiplier);
                }
            }
        }
    }
}