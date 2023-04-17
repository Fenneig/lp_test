namespace LavaProject.Inventory.Abstract
{
    public interface IInventoryItem
    {
        IInventoryItemInfo Info { get; }
        IInventoryItemState State { get; }
        IInventoryItem Clone();
    }
}