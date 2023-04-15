using System;

namespace LavaProject.Inventory.Abstract
{
    public interface IInventory
    {
        IInventoryItem GetItem(Type itemType);
        IInventoryItem[] GetAllItems();
        IInventoryItem[] GetAllItems(Type itemType);
        int GetItemAmount(Type itemType);

        void Add(object sender, IInventoryItem item);
        void Remove(object sender, Type itemType, int amount = 1);
        bool HasItem(Type type, out IInventoryItem item);
    }
}