using System;
using LavaProject.Inventory.Abstract;

namespace LavaProject.Inventory
{
    public class InventorySlot : IInventorySlot
    {
        public bool IsEmpty => Item == null;
        public IInventoryItem Item { get; private set; }
        public Type ItemType => Item.Type;
        public int Amount => IsEmpty ? 0 : Item.Amount; 
        
        public void SetItem(IInventoryItem item)
        {
            if (!IsEmpty) return;

            Item = item;
        }

        public void Clear()
        {
            if (IsEmpty) return;

            Item.Amount = 0;
            Item = null;
        }
    }
}