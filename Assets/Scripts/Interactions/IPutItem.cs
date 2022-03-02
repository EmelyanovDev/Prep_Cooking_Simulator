using Items;
using UnityEngine;

namespace Interactions
{
    public interface IPutItem
    {
        bool CanPutItem();
        Vector3 PutItem(Item putItem);
    }
}