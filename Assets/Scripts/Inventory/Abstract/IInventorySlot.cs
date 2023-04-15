using System;

namespace LavaProject.Inventory.Abstract
{
    public interface IInventorySlot
    {
        bool IsEmpty { get; }
        
        IInventoryItem Item { get; }
        Type ItemType { get; }
        int Amount { get; }

        void SetItem(IInventoryItem item);
        void Clear();
    }
}