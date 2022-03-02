using Items;

namespace Interactions
{
    public interface IPickItem
    {
        bool CanPickItem(); 
        Item PickItem();
    }
}