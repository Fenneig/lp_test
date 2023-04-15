using System;

namespace LavaProject.Inventory.Abstract
{
    public interface IInventoryItem
    {
        Type Type { get; }
        int Amount { get; set; }

        IInventoryItem Clone();
    }
}