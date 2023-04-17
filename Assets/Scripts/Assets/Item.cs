using System;
using LavaProject.Inventory;
using LavaProject.Inventory.Abstract;

namespace LavaProject.Assets
{
    public class Item : IInventoryItem
    {
        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        public Type Type => GetType();

        public Item(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedItem = new Item(Info);
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }
    }
}